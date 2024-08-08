using Vehicles;
using Vehicles.VehicleAspects;
using Vehicles.VehicleTypes;
using StringRepository;

public static class PlayGame
{
  private static readonly Random getRandom = new Random();
  private static readonly string newLine = Environment.NewLine;
  private static readonly List<string> cities = new List<string> {"London", "Birmingham", "Edinburgh", "Sheffield",
        "Nottingham", "Leeds", "Glasgow", "Cardiff", "Aberystwyth", "Manchester"};
  private static readonly string city = cities[GetRandomNumber(0, cities.Count - 1, getRandom)];
  private static readonly int daysToComplete = GetRandomNumber(6, 12, getRandom);
  public static int Money { get; set; } = 12000;
  private static bool gameBeingPlayed = true;
  public static void Run()
  {
    System.Console.WriteLine($"Welcome to X! On this journey, you will be travelling to {city}! You have {daysToComplete} to get there!" + newLine);
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
    System.Console.WriteLine("Please select one of the following vehicles by typing the corresponding number Please note the cost of the car, as this take up part of your budget:" + newLine);
    PrintVehicles();
    do
    {
      string input = Console.ReadLine();
      int.TryParse(input, out int userChoice);
      if (input == "E")
      {
        gameBeingPlayed = false;
        continue;
      }
      else if (userChoice < 1 || userChoice > Enum.GetNames(typeof(Vehicles.Vehicles)).Length)
      {
        System.Console.WriteLine("Incorrect input, please type a valid input, or type 'E' to exit.");
        continue;
      }
      VehicleBuilder(userChoice);

    } while (gameBeingPlayed);

  }

  public static string VehicleToString(Vehicles.Vehicles vehicle)
  {
    return Enum.GetName(typeof(Vehicles.Vehicles), vehicle);
  }

  public static void VehicleBuilder(int index)
  {
    Vehicle vehicle;
    Vehicles.Vehicles vehicleChoice = (Vehicles.Vehicles)index - 1;
    string vehicleChoiceUserReadable = EnumDescriber.Wordify(VehicleToString((Vehicles.Vehicles)index - 1));
    System.Console.WriteLine("Your choice of vehicle: " + EnumDescriber.Wordify(VehicleToString((Vehicles.Vehicles)index - 1)));
    System.Console.WriteLine($"You now have the option to customise your {vehicleChoiceUserReadable}. Please type 'Y' or 'N' for each possible upgrade presented to you:");
    bool choiceToUpgrade = true;
    string upgradeChoice;
    string userPointInUpgradeDecision = "Tyres";
    do
    {
      if (userPointInUpgradeDecision == "Tyres")
      {
        System.Console.WriteLine("Would you like to upgrade your tyres to winter tyres? These will help cross muddy terrain if it has been raining. (-£500)");
        upgradeChoice = Console.ReadLine().ToUpper();
        if (upgradeChoice == "Y" && (Money - 500) > 0)
        {
          System.Console.WriteLine("You upgrade of {} has been applied to your {}! You have {} remaining of your budget");
        }
        else if (upgradeChoice != "N")
        {
          System.Console.WriteLine("Invalid input. Please try again.");
          continue;
        }
        userPointInUpgradeDecision == 
      }
    } while (choiceToUpgrade);
    System.Console.WriteLine();
    switch (vehicleChoice)
    {
      case Vehicles.Vehicles.FordFocus:
        Vehicle userVehicle = new Hatchback(new Wheels());
        break;
      case Vehicles.Vehicles.FiatPanda:
        System.Console.WriteLine("f2");
        break;
      case Vehicles.Vehicles.RangeRover:
        break;
      case Vehicles.Vehicles.JeepWrangler:
        break;
      case Vehicles.Vehicles.KawasakiNinja:
        break;
      case Vehicles.Vehicles.KTMEnduro:
        break;
      case Vehicles.Vehicles.MercedesSLK:
        break;
      case Vehicles.Vehicles.LamborghiniGallardo:
        break;

    }
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
    foreach (Vehicles.Vehicles vehicle in Enum.GetValues(typeof(Vehicles.Vehicles)))
    {
      // System.Console.WriteLine("Vehicle is: " + Enum.GetName(typeof(Vehicles), vehicle));
      Console.WriteLine($"{(int)vehicle + 1}. {EnumDescriber.Wordify(VehicleToString(vehicle))}");
    }
  }
}
