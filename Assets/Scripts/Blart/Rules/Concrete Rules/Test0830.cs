public class Test0830 : IRule
{
  public override bool CheckRuleBroken()
  {
    return MallStateDTO.timeInSeconds > 30600;
  }
}
