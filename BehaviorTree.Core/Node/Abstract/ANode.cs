using BehaviorTree.Core.Tree;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;

namespace BehaviorTree.Core.Node.Abstract
{
    public abstract class ANode
    {
        public string name;

        public ANode(string pName = "")
        {
            name = pName;
        }

        public abstract TickResult Tick(Blackboard pWorldContext, Blackboard pMemory);

    }
}