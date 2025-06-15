using System;
using System.Diagnostics;

public class Test0700 : IRule
{
  public override bool CheckRuleBroken()
  {
    return MallStateDTO.timeInSeconds > 25200;
  }
}
