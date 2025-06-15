using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
  [HideInInspector]
  public RuleManager instance;
  public float timeScale = 120f;

  void Start()
  {
    if (instance)
    {
      Debug.LogWarning("Warning, multiple rule managers exist in the scene!");
    }
    else
    {
      instance = this;
    }
  }

  void Update()
  {
    UpdateMall();
  }

  private void UpdateMall()
  {
    MallStateDTO.people = 0;
    MallStateDTO.beggers = 0;
    MallStateDTO.children = 0;
    MallStateDTO.running = false;
    MallStateDTO.timeInSeconds += Time.deltaTime * timeScale;
  }

  private void StartFirstShift()
  {
    MallStateDTO.timeInSeconds = 21600; // I.e., 06:00
  }

  private void StartSecondShift()
  {
    MallStateDTO.timeInSeconds = 46800; // I.e., 13:00
  }
}
