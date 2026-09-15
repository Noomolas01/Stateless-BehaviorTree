// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using StatelessBehaviorTree.Core.Node.Abstract;
using StatelessBehaviorTree.Core.Tree.Blackboard;
using StatelessBehaviorTree.Core.Tree.Interfaces;
using StatelessBehaviorTree.Core.Tree.Results;

namespace StatelessBehaviorTree.Core.Node.Leaf.Abstract
{
    /// <summary>
    /// Base class for condition node
    /// </summary>
    public abstract class AConditionNode : ANode
    {
        public AConditionNode(string pName = "") : base(pName) { }

        protected abstract bool Evaluate(Blackboard pWorldContext, Blackboard pMemory);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="pWorldContext"> <inheritdoc/> </param>
        /// <param name="pMemory"> <inheritdoc/> </param>
        /// <param name="pTickHook"></param>
        /// <returns></returns>
        public override TickResult Tick(Blackboard pWorldContext, Blackboard pMemory, ITickHook? pTickHook = null)
        {
            bool lConditionMet = Evaluate(pWorldContext, pMemory);

            return lConditionMet ? new TickResult(NodeStatus.SUCCESS, null, pMemory) : new TickResult(NodeStatus.FAILURE, null, pMemory);
        }
    }
}
