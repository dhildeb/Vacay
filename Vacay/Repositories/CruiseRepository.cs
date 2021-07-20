using System;
using Vacay.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;
using System.Linq;

namespace Vacay.Repositories
{
  class CruiseRepository
  {
    private readonly IDbConnection _db;
    public CruiseRepository(IDbConnection db)
    {
      _db = db;
    }
    public List<Cruise> GetAll()
    {
      var sql = "SELECT * FROM cruises";
      return _db.Query<Cruise>(sql).ToList();
    }

    public Cruise GetById(string id)
    {
      var sql = @"SELECT * FROM cruises WHERE cruises.id = @id";
      return _db.Query<Cruise>(sql, new { id }).FirstOrDefault();
    }
    public Cruise PostCruise(Cruise cruiseData)
    {
      var sql = @"
      INSERT INTO cruise
      cruise(creatorId, destination, price, days, capacity, events)
      VALUES(@CreatorId, @Destination, @Price, @Days, @Capacity, @Events)
      SELECT LAST_INCIDENT_ID();
      ";
      return _db.ExecuteScalar<Cruise>(sql, cruiseData);
    }


    public ActionResult<Cruise> EditCruise(Cruise cruiseData)
    {
      var sql = @"
      UPDATE cruises
      SET 
      destination = @Destination,
      price = @Price, 
      days = @Days,
      capacity = @Capacity,
      events = @Events,
      WHERE id = @Id
      ";
      _db.Execute(sql, cruiseData);
      return cruiseData;
    }

    public void DeleteCruise(string cruiseId)
    {
      var sql = "DELETE FROM cruises WHERE cruises.id = cruiseId limit 1";
      _db.Execute(sql, new { cruiseId });
    }
  }
}