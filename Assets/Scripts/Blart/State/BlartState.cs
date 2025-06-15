using System;
using System.Collections.Generic;
using UnityEditor.Search;

public static class BlartState
{
  public static HashSet<StoreItemDTO> items = new();
  public static GunDTO gun;
  public static SegwayDTO segway;
  public static int chamberCount;
  public static int stockpileCount;

  public static HashSet<GunDTO> GetGuns()
  {
    HashSet<GunDTO> guns = new();
    foreach (StoreItemDTO item in items)
    {
      if (item is GunDTO gun)
      {
        guns.Add(gun);
      }
    }

    return guns;
  }

  public static HashSet<SegwayDTO> GetSegways()
  {
    HashSet<SegwayDTO> segs = new();
    foreach (StoreItemDTO item in items)
    {
      if (item is SegwayDTO seg)
      {
        segs.Add(seg);
      }
    }

    return segs;
  }
}
