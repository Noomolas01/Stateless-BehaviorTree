using BehaviorTree.Core.Tree;
using BehaviorTree.Core.Tree.DataManagement;

namespace BehaviorTree.Core.Node.Abstract
{
    public abstract class AActionNode: ANode
    {
        public AActionNode(string pName = "") : base(pName) { }
        public bool HasStarted { get; protected set; }
        protected abstract TickResult Do(WorldContext pWorldContext, Blackboard pBlackboard);

        public override TickResult Tick(WorldContext pWorldContext, Blackboard pBlackboard)
        {
            return Do(pWorldContext, pBlackboard);
        }
    }

}