using Vehicles.VehicleAspects;

namespace Vehicles.VehicleTypes;
public class Hatchback : Vehicle
{
  public Hatchback(string name) :
  base(name, new FuelTank(50, 50))
  {
  };
}
