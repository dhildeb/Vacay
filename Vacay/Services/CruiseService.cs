using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vacay.Models;
using Vacay.Repositories;

namespace Vacay.Services
{
  class CruiseService
  {
    private readonly CruiseRepository _cr;

    public CruiseService(CruiseRepository cr)
    {
      _cr = cr;
    }

    public List<Cruise> GetAll()
    {
      return _cr.GetAll();
    }

    public Cruise GetById(string id)
    {
      return _cr.GetById(id);
    }

    public Cruise PostCruise(Cruise cruiseData, string id)
    {
      cruiseData.CreatorId = id;
      return _cr.PostCruise(cruiseData);
    }

    public ActionResult<Cruise> EditCruise(Cruise cruiseData, string id)
    {
      var cruise = GetById(cruiseData.Id);

      if (cruise == null)
      {
        throw new Exception("Invalid Id");
      }
      if (cruise.CreatorId != id)
      {
        throw new Exception("Not Authorized, only the creator can make changes.");
      }
      return _cr.EditCruise(cruiseData);
    }

    public void DeleteCruise(string UserId, string CruiseId)
    {
      var cruise = GetById(CruiseId);
      if (cruise.CreatorId != UserId)
      {
        throw new Exception("Not Authorized, only creator can delete this.");
      }
      _cr.DeleteCruise(CruiseId);
    }
  }
}