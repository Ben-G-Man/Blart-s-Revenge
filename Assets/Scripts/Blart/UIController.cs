using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
  public Image clock;
  public Text clockText;
  public Image id;

  public Sprite[] idStates;
  public Sprite[] clockStages;

  void Update()
  {
    UpdateClock();
    UpdateId();
  }

  private void UpdateClock()
  {
    int time = (int)MallStateDTO.timeInSeconds;
    clockText.text = FormatTimeOfDay(time);

    switch (MallStateDTO.GetPhase())
    {
      case MallStateDTO.Phase.FIRST_SHIFT:
        if (clockStages[0])
        {
          clock.sprite = clockStages[0];
        }
        else
        {
          Debug.LogWarning("Warning! No first shift clock sprite!");
        }
        break;
      case MallStateDTO.Phase.LUNCH_BREAK:
        if (clockStages[1])
        {
          clock.sprite = clockStages[1];
        }
        else
        {
          Debug.LogWarning("Warning! No lunch clock sprite!");
        }
        break;
      case MallStateDTO.Phase.SECOND_SHIFT:
        if (clockStages[2])
        {
          clock.sprite = clockStages[2];
        }
        else
        {
          Debug.LogWarning("Warning! No second shift clock sprite!");
        }
        break;
      default:
        if (clockStages[3])
        {
          clock.sprite = clockStages[3];
        }
        else
        {
          Debug.LogWarning("Warning! No bedtime clock sprite!");
        }
        break;
    }
  }

  private void UpdateId()
  {
    int violations = Mathf.Clamp(RuleManager.instance.GetViolationCount(), 0, 3);
    if (idStates.Length - 1 >= violations)
    {
      id.sprite = idStates[violations];
    }
    else
    {
      Debug.LogWarning("Warning! No ID sprite for " + violations + " violations!");
    }
  }

  public static string FormatTimeOfDay(int secondsSinceMidnight)
  {
    secondsSinceMidnight = Mathf.Clamp(secondsSinceMidnight, 0, 86399);

    int totalMinutes = secondsSinceMidnight / 60;
    int hours = totalMinutes / 60;
    int minutes = totalMinutes % 60;
    string period = (hours < 12) ? "AM" : "PM";
    int displayHour = hours % 12;
    if (displayHour == 0) displayHour = 12;
    return $"{displayHour:D2}:{minutes:D2} {period}";
  }
}
