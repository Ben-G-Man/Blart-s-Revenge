using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class RuleManager : MonoBehaviour
{
  [HideInInspector]
  public static RuleManager instance;
  [HideInInspector]
  private static IRule[] allRules;
  [HideInInspector]
  public IRule[] rules = {null, null, null, null};

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
      ChooseRules();
    }
  }

  private void ChooseRules()
  {
    rules[0] = new Test0700();
    rules[1] = new Test0730();
    rules[2] = new Test0800();
    rules[3] = new Test0830();
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

  public int GetViolationCount()
  {
    int violations = 0;

    foreach (IRule rule in rules)
    {
      if (rule.CheckRuleBroken())
      {
        violations++;
      }
    }

    return violations;
  }

  public float GetPayDock()
  {
    float percentageDocked = 0f;

    foreach (IRule rule in rules)
    {
      if (!rule.CheckRuleBroken())
      {
        percentageDocked += rule.weight;
      }
    }

    return Mathf.Clamp01(percentageDocked);
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
