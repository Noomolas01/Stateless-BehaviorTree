using BehaviorTree.Core.Tree;

namespace BehaviorTree.Core.Node.Abstract;

public abstract class ANode(string pName = "")
{
    public string name = pName;

    public abstract TickResult Tick(WorldContext pWorldState, Blackboard pBlackboard);
}
