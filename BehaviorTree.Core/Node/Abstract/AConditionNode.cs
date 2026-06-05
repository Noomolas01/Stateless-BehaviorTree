using BehaviorTree.Core.Tree;

namespace BehaviorTree.Core.Node.Abstract;

public abstract class AConditionNode(string pName = "") : ANode(pName)
{
    protected abstract bool Evaluate(WorldContext pWorldState, Blackboard pBlackboard);

    public override TickResult Tick(WorldContext pWorldState, Blackboard pBlackboard)
    {
        bool lConditionMet = Evaluate(pWorldState, pBlackboard);

        return lConditionMet ? new TickResult(NodeStatus.SUCCESS, null)  : new TickResult(NodeStatus.FAILURE, null);
    }
}
