public class Test0800 : IRule
{
  public override bool CheckRuleBroken()
  {
    return MallStateDTO.timeInSeconds > 28800;
  }

  public override string GetText()
  {
    return "Uhhh nobody in mall after 0800 :)";
  }
}
