public abstract class Vehicle(List<Wheel> wheels, Suspension suspension, Engine engine, FuelTank fuelTank, Colour colour, int topSpeed, int mpg, string name) : IVehicle
{
  public List<Wheel> Wheels { get; set; } = wheels;
  public Suspension Suspension { get; set; } = suspension;
  public Engine Engine { get; set; } = engine;
  public FuelTank FuelTank { get; set; } = fuelTank;
  public Colour Colour { get; set; } = colour;
  public int TopSpeed { get; init; } = topSpeed;
  public double MilesUntilNoFuel { get; set; } = GetMilesUntilNoFuel(mpg, fuelTank.RemaningFuelInLitres);
  public int MilesPerGallon { get; } = mpg;
  public string Name { get; } = name;


  public static double GetMilesUntilNoFuel(int mpg, int litresOfFuelLeft)
  {
    return Math.Round(mpg * (litresOfFuelLeft / 4.54), 1);
  }

  public void Drive(int distance)
  {
    MilesUntilNoFuel -= distance;
  }

  public void Refuel(int amount)
  {
    throw new NotImplementedException();
  }
}
