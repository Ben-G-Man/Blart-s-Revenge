using System;

public class GunDTO : StoreItemDTO
{
  public GunDTO(string name, int capacity, float reloadSpeed, float cooldown)
  {
    this.name = name;
    this.capacity = capacity;
    this.reloadSpeed = reloadSpeed;
    this.cooldown = cooldown;
  }

  public int capacity;
  public float reloadSpeed;
  public float cooldown;

  public override float GetPrice()
  {
    return 9.99f;
  }
}
