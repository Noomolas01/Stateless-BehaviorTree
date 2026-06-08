using BehaviorTree.Core.Tree;

namespace BehaviorTree.Core.Node.Abstract
{
    public abstract class ANode
    {
        public string name;

        public ANode(string pName = "")
        {
            name = pName;
        }

        public abstract TickResult Tick(WorldContext pWorldState, Blackboard pBlackboard);
    }
}