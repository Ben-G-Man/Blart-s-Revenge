public class Test0830 : IRule
{
  public override bool CheckRuleBroken()
  {
    return MallStateDTO.timeInSeconds > 30600;
  }

  public override string GetText()
  {
    return "Uhhh nobody in mall after 0800 :)";
  }
}
