using System;
using Vacay.Interface;

namespace Vacay.Models
{
  class Trip : ITravel
  {
    public string Id { get; set; }
    public string CreatorId { get; set; }
    public string Destination { get; set; }
    public int Price { get; set; }
    public int Days { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

  }
}