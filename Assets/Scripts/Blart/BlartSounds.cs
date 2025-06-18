using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlartSounds : MonoBehaviour
{
  [HideInInspector]
  public static BlartSounds instance;
  public AudioSource source;

  void Start()
  {
    if (instance)
    {
      Debug.LogWarning("Warning, multiple blart sound scripts exist in the scene!");
    }
    else
    {
      instance = this;
    }
  }
}
