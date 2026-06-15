using BehaviorTree.Core.Tree;
using BehaviorTree.Core.Tree.DataManagement;

namespace BehaviorTree.Core.Node.Abstract
{

    public abstract class AConditionNode : ANode
    {
        public AConditionNode(string pName = "") : base(pName) { }

        protected abstract bool Evaluate(WorldContext pWorldContext, Blackboard pBlackboard);

        public override TickResult Tick(WorldContext pWorldContext, Blackboard pBlackboard)
        {
            bool lConditionMet = Evaluate(pWorldContext, pBlackboard);

            return lConditionMet ? new TickResult(NodeStatus.SUCCESS, null, pBlackboard) : new TickResult(NodeStatus.FAILURE, null, pBlackboard);
        }
    }
}
