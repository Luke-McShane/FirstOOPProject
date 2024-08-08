

using Vehicles.VehicleAspects;

namespace Vehicles;

public abstract class Vehicle(Wheels wheels, Suspension suspension, Engine engine, FuelTank fuelTank, Colour colour, int topSpeed, int mpg, string name) : IVehicle
{
  // protected Vehicle(List<Wheel> wheels, Suspension suspension, Engine engine, FuelTank fuelTank, Colour colour, int topSpeed, int mpg, string name)
  // {
  //     TopSpeed = topSpeed;
  //     Name = name;
  // }

  public Wheels Wheels { get; set; } = wheels;
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

public interface IVehicle
{
  public void Refuel(int amount);
  public void Drive(int distance);
}

public enum Vehicles
{
  FordFocus,
  FiatPanda,
  RangeRover,
  JeepWrangler,
  KawasakiNinja,
  KTMEnduro,
  MercedesSLK,
  LamborghiniGallardo

}

public enum VehicleCosts
{
  FordFocus = 5000,
  FiatPanda = 3500,
  RangeRover = 9000,
  JeepWrangler = 8000,
  KawasakiNinja = 5000,
  KTMEnduro = 4500,
  MercedesSLK = 10000,
  LamborghiniGallardo = 11000
}
