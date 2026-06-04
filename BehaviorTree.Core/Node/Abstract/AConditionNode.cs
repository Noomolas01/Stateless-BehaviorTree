using BehaviorTree.Core.Tree;

namespace BehaviorTree.Core.Node.Abstract;

public abstract class AConditionNode(string pName = "") : ANode(pName)
{
    protected abstract bool Evaluate();

    public override TickResult Tick(WorldState pWorldState, Blackboard pBlackboard)
    {
        bool lConditionMet = Evaluate();

        return lConditionMet ? new TickResult(NodeStatus.SUCCESS, null)  : new TickResult(NodeStatus.FAILURE, null);
    }
}
