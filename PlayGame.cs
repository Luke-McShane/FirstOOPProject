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
    Console.WriteLine($"Welcome to X! On this journey, you will be travelling to {city}! You have {daysToComplete} to get there!" + newLine);
    Console.WriteLine(@$"You have £{Money} to spend on buying a car. You will also have the opportunity to make improvements/
    customisations to your car before you start your journey, so it may be better to save some money for this. Also, you
    might want to save some money for if your vehicle breaks down on the journey.");
    Console.WriteLine(@"Each day will be different on your journey.The weather will change, and you will come across different challenges,
     forcing you to make a decision which may impact the stress of the driver, the condition of the car, and the amount
      of time taken to get to the destination. And, you must consider that a single mistake could lead you to not being
       able to complete the journey!");
    Console.WriteLine(@$"If you make it to the finish line, you will receive a score based on:{newLine}--> The amount of days you had to spare.
                                {newLine}--> The stress level of your driver.
                                {newLine}--> How much cash you had to spare.
                                {newLine}--> How 'cool' your car is (a paintjob will help in this regard).");
    Console.WriteLine("Please select one of the following vehicles by typing the corresponding number Please note the cost of the car, as this take up part of your budget:" + newLine);
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
        Console.WriteLine("Incorrect input, please type a valid input, or type 'E' to exit.");
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
    Console.WriteLine("Your choice of vehicle: " + EnumDescriber.Wordify(VehicleToString((Vehicles.Vehicles)index - 1)));
    Console.WriteLine($"You now have the option to customise your {vehicleChoiceUserReadable}. Please type 'Y' or 'N' for each possible upgrade presented to you:");
    bool choiceToUpgrade = true;
    string upgradeChoice;
    string userPointInUpgradeDecision = "Tyres";
    do
    {
      if (userPointInUpgradeDecision == "Tyres")
      {
        Console.WriteLine("Would you like to upgrade your tyres to winter tyres? These will help cross muddy terrain if it has been raining. (-£500)");
        upgradeChoice = Console.ReadLine().ToUpper();
        if (upgradeChoice == "Y" && (Money - 500) > 0)
        {
          Console.WriteLine($"You upgrade of {TyreType.Winter} tyres has been applied to your {vehicleChoiceUserReadable}! You have {Money} remaining of your budget");
          Money -= 500;
        }
        else if (upgradeChoice != "N")
        {
          Console.WriteLine("Invalid input. Please try again.");
          continue;
        }
        userPointInUpgradeDecision = "Engine";
      }

      else if (userPointInUpgradeDecision == "Engine")
      {
        Console.WriteLine($"Would you like to upgrade your engine so it's turbocharged? This will the speed of your {vehicleChoiceUserReadable}. (-£1000)");
        upgradeChoice = Console.ReadLine().ToUpper();
        if (upgradeChoice == "Y" && (Money - 1000) > 0)
        {
          Money -= 1000;
          Console.WriteLine($"Your turbocharger has been fitted to your {vehicleChoiceUserReadable}! You have {Money} remaining of your budget");
        }
        else if (upgradeChoice != "N")
        {
          Console.WriteLine("Invalid input. Please try again.");
          continue;
        }
        userPointInUpgradeDecision = "Driver";
      }
      else if (userPointInUpgradeDecision == "Driver")
      {
        Console.WriteLine("Would you like to swap out your driver for someone more calm and collected? This will help the journey run smoothly and your score will be increased if you make it to the destination if your driver is less stressed. (-£750)");
        upgradeChoice = Console.ReadLine().ToUpper();
        if (upgradeChoice == "Y" && (Money - 750) > 0)
        {
          Money -= 750;
          Console.WriteLine($"You now have a more relaxed driver! You have {Money} remaining of your budget");
        }
        else if (upgradeChoice != "N")
        {
          Console.WriteLine("Invalid input. Please try again.");
          continue;
        }
        userPointInUpgradeDecision = "Colour";
      }
      else if (userPointInUpgradeDecision == "Colour")
      {
        Console.WriteLine("Would you like to add an impressive paint? These style points will bolster your score if you make it to the destination. (-£500)");
        upgradeChoice = Console.ReadLine().ToUpper();
        if (upgradeChoice == "Y" && (Money - 500) > 0)
        {
          Money -= 500;
          Console.WriteLine($"Your snazzy paint job has been applied to your {vehicleChoiceUserReadable}! You have {Money} remaining of your budget, and no more upgrades are available.");
        }
        else if (upgradeChoice != "N")
        {
          Console.WriteLine("Invalid input. Please try again.");
          continue;
        }
        choiceToUpgrade = false;
      }
    } while (choiceToUpgrade);
    Console.WriteLine();
    switch (vehicleChoice)
    {
      case Vehicles.Vehicles.FordFocus:
        // Vehicle userVehicle = new Hatchback(new Wheels());
        break;
      case Vehicles.Vehicles.FiatPanda:
        Console.WriteLine("f2");
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
    // foreach (Vehicles.Vehicles vehicle in Enum.GetValues(typeof(Vehicles.Vehicles)))
    // {
    //   // System.Console.WriteLine("Vehicle is: " + Enum.GetName(typeof(Vehicles), vehicle));
    //   Console.WriteLine($"{(int)vehicle + 1}. {EnumDescriber.Wordify(VehicleToString(vehicle))}");

    // }
    for (int i = 0; i < nameof(Vehicles.Vehicles).Length; ++i)
    {
      string local = Enum.GetName(typeof(VehicleCosts), i);
      // System.Console.WriteLine("Vehicle is: " + Enum.GetName(typeof(Vehicles), vehicle));
      // Console.WriteLine($"{i + 1}. {EnumDescriber.Wordify(VehicleToString((Vehicles.Vehicles)i + 1))}. Cost: {(VehicleCosts)i + 1}");
      System.Console.WriteLine((int)(VehicleCosts)i);

    }
  }
}
