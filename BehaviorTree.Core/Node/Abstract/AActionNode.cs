using BehaviorTree.Core.Tree;
using BehaviorTree.Core.Tree.DataManagement;

namespace BehaviorTree.Core.Node.Abstract
{
    public abstract class AActionNode: ANode
    {
        public AActionNode(string pName = "") : base(pName) { }
        public bool HasStarted { get; protected set; }
        protected abstract TickResult Do(Blackboard pWorldContext, Blackboard pMemory);

        public override TickResult Tick(Blackboard pWorldContext, Blackboard pMemory)
        {
            return Do(pWorldContext, pMemory);
        }
    }

}