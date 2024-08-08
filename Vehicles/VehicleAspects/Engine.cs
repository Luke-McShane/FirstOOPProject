namespace Vehicles.VehicleAspects;
public class Engine(double litres) : Damageable
{
  public double Litres { get; init; } = litres;
  public bool IsTurbo { get; init; } = false;
}
