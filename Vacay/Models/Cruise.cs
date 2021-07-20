using Vacay.Interface;

namespace Vacay.Models
{
  class Cruise : ITravel
  {
    public string Id { get; set; }
    public string CreatorId { get; set; }
    public string Destination { get; set; }
    public int Price { get; set; }
    public int Days { get; set; }
    public int Capacity { get; set; }
    public string Events { get; set; }
  }
}