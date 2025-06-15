public class Test0800 : IRule
{
  public override bool CheckRuleBroken()
  {
    return MallStateDTO.timeInSeconds > 28800;
  }
}
