public class Test0730 : IRule
{
  public override bool CheckRuleBroken()
  {
    return MallStateDTO.timeInSeconds > 27000;
  }

  public override string GetText()
  {
    return "Uhhh nobody in mall after 0730 :)";
  }
}
