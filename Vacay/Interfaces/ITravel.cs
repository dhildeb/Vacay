namespace Vacay.Interface
{
  public interface ITravel
  {
    string Id { get; set; }
    string CreatorId { get; set; }
    string Destination { get; set; }
    int Price { get; set; }
    int Days { get; set; }
  }
}