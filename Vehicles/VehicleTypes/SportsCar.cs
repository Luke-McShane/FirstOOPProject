using Vehicles.VehicleAspects;

namespace Vehicles.VehicleTypes;
public abstract class SportsCar : Vehicle
{
  protected SportsCar(Wheels wheels, Colour colour, int topSpeed, int mpg, string name) :
  base(wheels, new Suspension(SuspensionType.Hard), new Engine(5.5), new FuelTank(80, 80), colour, topSpeed, mpg, name)
  {
  }
}
