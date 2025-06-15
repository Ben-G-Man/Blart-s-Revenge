using System;

public class SegwayDTO : StoreItemDTO
{
  public SegwayDTO(string name, float topSpeed, float acceleration, float powerConsumption, float suspension, float handling)
  {
    this.name = name;
    this.topSpeed = topSpeed;
    this.acceleration = acceleration;
    this.powerConsumption = powerConsumption;
    this.suspension = suspension;
    this.handling = handling;
  }

  public float topSpeed;
  public float acceleration;
  public float powerConsumption;
  public float suspension;
  public float handling;

  public override float GetPrice()
  {
    return 24.99f;
  }
}
