using System;
using System.Diagnostics;

public class Test0700 : IRule
{
  public override bool CheckRuleBroken()
  {
    return MallStateDTO.timeInSeconds > 25200;
  }

  public override string GetText()
  {
    return "Uhhh nobody in mall after 0700 :)";
  }
}

