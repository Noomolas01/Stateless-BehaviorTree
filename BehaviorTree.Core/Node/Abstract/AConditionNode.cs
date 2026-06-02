namespace BehaviorTree.Core.Node.Abstract;

public abstract class AConditionNode(string pName = "") : ANode(pName)
{
    protected abstract bool Evaluate();

    public override Result Tick()
    {
        bool lConditionMet = Evaluate();

        return lConditionMet ? Result.SUCCESS : Result.FAILURE;
    }
}
