using BehaviorTree.Core.Tree;

namespace BehaviorTree.Core.Node.Abstract;

public abstract class AActionNode (string pName = "") : ANode(pName)
{
    public bool HasStarted {get; protected set;}
    protected abstract TickResult Do();

    public override TickResult Tick(WorldState pWorldState, Blackboard pBlackboard)
    {
        return Do();
    }
}
