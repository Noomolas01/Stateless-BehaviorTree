namespace BehaviorTree.Core.Node.Abstract;

public abstract class AConditionNode(string pName = "") : ANode(pName)
{
    protected abstract bool Evaluate();

    public override TickResult Tick()
    {
        bool lConditionMet = Evaluate();

        return lConditionMet ? new TickResult(NodeStatus.SUCCESS, null)  : new TickResult(NodeStatus.FAILURE, null);
    }
}
