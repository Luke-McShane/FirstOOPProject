using Vehicles.VehicleAspects;

namespace Vehicles.VehicleTypes;
public class SUV : Vehicle
{
  protected SUV(Wheels wheels, Colour colour, int topSpeed, int mpg, string name) :
  base(wheels, new Suspension(SuspensionType.Soft), new Engine(3.5), new FuelTank(90, 90), colour, topSpeed, mpg, name)
  {
  }
}
