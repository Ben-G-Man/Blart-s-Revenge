using System.Diagnostics;

public class CapacityRule : IRule
{
  int maxPeople;

  public CapacityRule(int maxPeople)
  {
    this.maxPeople = maxPeople;
  }

  public override bool CheckRuleBroken()
  {
    return RuleManager.instance.GetCustomerCount() > maxPeople;
  }

  public override string GetText()
  {
    return "No more than " + maxPeople + " people in the mall.";
  }
}
