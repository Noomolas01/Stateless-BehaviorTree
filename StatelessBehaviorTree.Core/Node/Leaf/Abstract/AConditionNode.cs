// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Interfaces;
using BehaviorTree.Core.Tree.Results;

namespace BehaviorTree.Core.Node.Leaf.Abstract
{
    public abstract class AConditionNode : ANode
    {
        public AConditionNode(string pName = "") : base(pName) { }

        protected abstract bool Evaluate(Blackboard pWorldContext, Blackboard pMemory);

        public override TickResult Tick(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickObserver = null)
        {
            bool lConditionMet = Evaluate(pWorldContext, pMemory);

            return lConditionMet ? new TickResult(NodeStatus.SUCCESS, null, pMemory) : new TickResult(NodeStatus.FAILURE, null, pMemory);
        }
    }
}
