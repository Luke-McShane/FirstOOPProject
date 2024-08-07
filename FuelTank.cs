public class FuelTank
{
  public int MaxCapacity { get; init; }
  public int RemaningFuelInLitres { get; set; }
  public string ShowRemaning => $"You have {RemaningFuelInLitres} miles left.";
}
