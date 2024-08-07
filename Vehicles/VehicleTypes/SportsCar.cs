public abstract class SportsCar : Vehicle
{
  protected SportsCar(List<Wheel> wheels, Suspension suspension, Engine engine, FuelTank fuelTank, Colour colour, int topSpeed, int mpg, string name) : base(wheels, suspension, engine, fuelTank, colour, topSpeed, mpg, name)
  {
  }
}
