public abstract class IRule
{
  public float weight = 0.25f; // A value between 0 and 1 corresponding with the amount of the user's pay rate to dock. 
  public abstract bool CheckRule();
}
