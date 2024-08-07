using Vehicles.VehicleAspects;

namespace Vehicles.VehicleTypes;
public abstract class Motorbike : Vehicle
{
  protected Motorbike(Wheels wheels, Colour colour, int topSpeed, int mpg, string name) :
  base(wheels, new Suspension(SuspensionType.Hard), new Engine(1.0), new FuelTank(17, 17), colour, topSpeed, mpg, name)
  {
  }
}
