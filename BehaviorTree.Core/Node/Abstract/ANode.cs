using BehaviorTree.Core.Tree;
using BehaviorTree.Core.Tree.DataManagement;

namespace BehaviorTree.Core.Node.Abstract
{
    public abstract class ANode
    {
        public string name;

        public ANode(string pName = "")
        {
            name = pName;
        }

        public abstract TickResult Tick(WorldContext pWorldContext, Blackboard pBlackboard);
    }
}