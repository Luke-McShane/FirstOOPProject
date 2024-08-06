public interface IVehicle
{
  public void Refuel(int amount);
  public void Drive(int distance);
}

public abstract class Vehicle(List<Wheel> wheels, Suspension suspension, Engine engine, FuelTank fuelTank, Colour colour, int topSpeed) : IVehicle
{
  public List<Wheel> Wheels { get; set; } = wheels;
  public Suspension Suspension { get; set; } = suspension;
  public Engine Engine { get; set; } = engine;
  public FuelTank FuelTank { get; set; } = fuelTank;
  public Colour Colour { get; set; } = colour;
  public int TopSpeed { get; init; } = topSpeed;
  protected int _milesUntilNoFuel;
  protected int _milesPerGallon;

  public Vehicle(List<Wheel> wheels, Suspension suspension, Engine engine, FuelTank fuelTank, Colour colour, int topSpeed)
  {

  }

  public void Drive(int distance)
  {
    _milesUntilNoFuel -= distance;
  }

  public void Refuel(int amount)
  {
    throw new NotImplementedException();
  }

  private void calculateMPG()
  {
    _milesPerGallon =
  }
}

public abstract class FuelTank
{
  public int MaxCapacity { get; init; }
  public float RemaningFuel { get; set; }
  public string ShowRemaning => $"You have {this.RemaningFuel} miles left.";
}

public abstract class Wheel
{
  public bool IsPunctured { get; set; } = false;
  public TyreType Type { get; init; }
}

public abstract class Damageable
{
  public bool IsDamaged { get; set; } = false;
}

public abstract class Suspension : Damageable
{
  public SuspensionType Type { get; init; }
}


public abstract class Engine : Damageable
{
  public float Litres { get; set; }
}

public class Driver : Damageable
{
  public int Money;
  public int StressLevel;

}

public enum Colour
{
  Blue,
  Yellow,
  Red,
  Green,
  Purple,
  Orange,

  Black,
  White,
  Silver,
  Custom
}

public enum TyreType
{
  Winter,
  Summer
}

public enum SuspensionType
{
  Hard,
  Soft
}