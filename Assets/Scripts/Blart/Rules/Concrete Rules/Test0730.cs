public class Test0730 : IRule
{
  public override bool CheckRuleBroken()
  {
    return MallStateDTO.timeInSeconds > 27000;
  }
}
