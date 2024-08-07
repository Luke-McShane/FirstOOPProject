
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

Main.Run();

public static class Main
{
  private static readonly Random getRandom = new Random();
  private static readonly string newLine = Environment.NewLine;
  private static readonly List<string> cities = new List<string> {"London", "Birmingham", "Edinburgh", "Sheffield",
        "Nottingham", "Leeds", "Glasgow", "Cardiff", "Aberystwyth", "Manchester"};
  private static readonly string city = cities[GetRandomNumber(0, cities.Count - 1, getRandom)];
  private static readonly int daysToComplete = GetRandomNumber(6, 12, getRandom);
  public static int Money { get; set; } = 12000;
  public static void Run()
  {
    System.Console.WriteLine($"Welcome to X! On this journey, you will be travelling to {city}! You have {daysToComplete} to get there!");
    System.Console.WriteLine(@$"You have £{Money} to spend on buying a car. You will also have the opportunity to make improvements/
                                customisations to your car before you start your journey, so it may be better to save some money for this. Also, you
                                might want to save some money for if your vehicle breaks down on the journey.");
    System.Console.WriteLine(@"Each day will be different on your journey.The weather will change, and you will come across different challenges,
                               forcing you to make a decision which may impact the stress of the driver, the condition of the car, and the amount
                               of time taken to get to the destination. And, you must consider that a single mistake could lead you to not being
                               able to complete the journey!");
    System.Console.WriteLine(@$"If you make it to the finish line, you will receive a score based on:{newLine}--> The amount of days you had to spare.
                                {newLine}--> The stress level of your driver.
                                {newLine}--> How much cash you had to spare.
                                {newLine}--> How 'cool' your car is (a paintjob will help in this regard).");
    System.Console.WriteLine("Please select one of the following vehicles by typing the corresponding number:" + newLine);
    PrintVehicles();
    int userCar =

  }
  public static int GetRandomNumber(int min, int max, Random getRandom)
  {
    lock (getRandom)
    {
      return getRandom.Next(min, max);
    }
  }

  static void PrintVehicles()
  {
    foreach (Vehicles vehicle in Enum.GetValues(typeof(Vehicles)))
    {
      // System.Console.WriteLine("Vehicle is: " + Enum.GetName(typeof(Vehicles), vehicle));
      Console.WriteLine($"{(int)vehicle + 1}. {EnumDescriber.Wordify(Enum.GetName(typeof(Vehicles), vehicle))}");
    }
  }
}
public interface IVehicle
{
  public void Refuel(int amount);
  public void Drive(int distance);
}

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

public abstract class SportsCar : Vehicle
{
  protected SportsCar(List<Wheel> wheels, Suspension suspension, Engine engine, FuelTank fuelTank, Colour colour, int topSpeed, int mpg, string name) : base(wheels, suspension, engine, fuelTank, colour, topSpeed, mpg, name)
  {
  }
}

public abstract class Motorbike : Vehicle
{
  protected Motorbike(List<Wheel> wheels, Suspension suspension, Engine engine, FuelTank fuelTank, Colour colour, int topSpeed, int mpg, string name) : base(wheels, suspension, engine, fuelTank, colour, topSpeed, mpg, name)
  {
  }
}

public abstract class SUV : Vehicle
{
  protected SUV(List<Wheel> wheels, Suspension suspension, Engine engine, FuelTank fuelTank, Colour colour, int topSpeed, int mpg, string name) : base(wheels, suspension, engine, fuelTank, colour, topSpeed, mpg, name)
  {
  }
}

public abstract class Hatchback : Vehicle
{
  protected Hatchback(List<Wheel> wheels, Suspension suspension, Engine engine, FuelTank fuelTank, Colour colour, int topSpeed, int mpg, string name) : base(wheels, suspension, engine, fuelTank, colour, topSpeed, mpg, name)
  {
  }
}

public class FuelTank
{
  public int MaxCapacity { get; init; }
  public int RemaningFuelInLitres { get; set; }
  public string ShowRemaning => $"You have {RemaningFuelInLitres} miles left.";
}

public class Wheel
{
  public bool IsPunctured { get; set; } = false;
  public TyreType Type { get; init; }
}

public class Damageable
{
  public bool IsDamaged { get; set; } = false;
}

public class Suspension : Damageable
{
  public SuspensionType Type { get; init; }
}


public class Engine : Damageable
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

public enum Cities
{
  London,
  Birmingham,
  Edinburgh,
  Sheffield,
  Nottingham,
  Leeds,
  Glasgow,
  Cardiff,
  Aberystwyth,
  Manchester
};

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

public static class EnumDescriber
{
  public static string Wordify(string pascalCaseString)
  {
    Regex r = new Regex("(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z])");
    return r.Replace(pascalCaseString, " ${x}");
  }
}