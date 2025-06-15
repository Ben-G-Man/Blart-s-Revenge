using System.Collections.Generic;
using UnityEngine;

public class BlartStore : MonoBehaviour
{
  public HashSet<StoreItemDTO> items = new();

  void Start()
  {
    items.Add(new GunDTO("Smith & Wesson Model 10", 6, 2.5f, 0.45f));
    items.Add(new GunDTO("Colt Python", 6, 2.0f, 0.35f));
    items.Add(new GunDTO("Beretta 92FS", 15, 1.5f, 0.25f));
    items.Add(new GunDTO("Glock 17", 17, 1.0f, 0.17f));

    items.Add(new SegwayDTO("Ol' Reliable", 20, 20, 0.1f, 1, 1));
    items.Add(new SegwayDTO("Pussy Waggon", 30, 20, 0.15f, 2, 1));
    items.Add(new SegwayDTO("Steed", 35, 25, 0.08f, 1.8f, 1));
  }
}
