namespace Vehicles.VehicleAspects;
public class FuelTank(int maxCapacity, int remainingFuelInLitres)
{
  public int MaxCapacityInLitres { get; init; } = maxCapacity;
  public int RemaningFuelInLitres { get; set; } = remainingFuelInLitres;
  public string ShowRemaning => $"You have {RemaningFuelInLitres} miles left.";
}
