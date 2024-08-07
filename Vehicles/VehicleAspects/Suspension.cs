namespace Vehicles.VehicleAspects;
public class Suspension(SuspensionType suspensionType) : Damageable
{
  public SuspensionType Type { get; init; } = suspensionType;
}

public enum SuspensionType
{
  Hard,
  Soft
}

