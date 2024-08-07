namespace Vehicles.VehicleAspects;
public class Wheels(TyreType tyreType)
{
  public bool IsPunctured { get; set; } = false;
  public TyreType Type { get; init; } = tyreType;
}

public enum TyreType
{
  Winter,
  Summer
}