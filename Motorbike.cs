public abstract class Motorbike : Vehicle
{
  protected Motorbike(List<Wheel> wheels, Suspension suspension, Engine engine, FuelTank fuelTank, Colour colour, int topSpeed, int mpg, string name) : base(wheels, suspension, engine, fuelTank, colour, topSpeed, mpg, name)
  {
  }
}
