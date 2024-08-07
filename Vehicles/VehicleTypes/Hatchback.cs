using Vehicles.VehicleAspects;

namespace Vehicles.VehicleTypes;
public class Hatchback : Vehicle
{
  protected Hatchback(Wheels wheels, Colour colour, int topSpeed, int mpg, string name) :
  base(wheels, new Suspension(SuspensionType.Hard), new Engine(1.4), new FuelTank(50, 50), colour, topSpeed, mpg, name)
  {
  }
}
