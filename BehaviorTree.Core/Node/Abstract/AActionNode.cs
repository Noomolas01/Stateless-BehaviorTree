using BehaviorTree.Core.Tree;

namespace BehaviorTree.Core.Node.Abstract;

public abstract class AActionNode (string pName = "") : ANode(pName)
{
    public bool HasStarted {get; protected set;}
    protected abstract TickResult Do(WorldContext pWorldState, Blackboard pBlackboard);

    public override TickResult Tick(WorldContext pWorldState, Blackboard pBlackboard)
    {
        return Do(pWorldState, pBlackboard);
    }
}
