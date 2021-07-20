using Vacay.Repositories;

namespace Vacay.Services
{
  class TripsService
  {
    private readonly TripsRepository _tp;

    public TripsService(TripsRepository tp)
    {
      _tp = tp;
    }
  }
}