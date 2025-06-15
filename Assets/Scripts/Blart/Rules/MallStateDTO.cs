using System;

public static class MallStateDTO
{
  public static int people = 0;
  public static int beggers = 0;
  public static int children = 0;
  public static bool running = false;
  public static float timeInSeconds = 21600;
  public static int trashCount = 0;

  public enum Phase
  {
    FIRST_SHIFT,
    LUNCH_BREAK,
    SECOND_SHIFT,
    BLART_O_CLOCK
  }

  public static Phase GetPhase()
  {
    int time = (int)timeInSeconds;
    if (time >= 21600 && time < 43200)
    {
      return Phase.FIRST_SHIFT;
    }
    else if (time >= 43200 && time < 46800)
    {
      return Phase.LUNCH_BREAK;
    }
    else if (time >= 46800 && time < 61200)
    {
      return Phase.SECOND_SHIFT;
    }
    else
    {
      return Phase.BLART_O_CLOCK;
    }
  }
}
