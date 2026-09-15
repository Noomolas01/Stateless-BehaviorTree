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
    /// Base class for action node 
    /// </summary>
    public abstract class AActionNode: ANode
    {
        public AActionNode(string pName = "") : base(pName) { }
        protected abstract TickResult Do(Blackboard pWorldContext, Blackboard pMemory);
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <remarks>
        /// Every class that inherits <see cref="Tick(Blackboard, Blackboard, ITickHook?)"/> from <see cref="AActionNode"/> should return a <see cref="TickResult"/> containing a <see cref="IAIDecision"/>.
        /// </remarks>
        /// <param name="pWorldContext"> <inheritdoc/> </param>
        /// <param name="pMemory"> <inheritdoc/> </param>
        /// <param name="pTickHook"></param>
        /// <returns></returns>
        public override TickResult Tick(Blackboard pWorldContext, Blackboard pMemory, ITickHook? pTickHook = null)
        {
            return Do(pWorldContext, pMemory);
        }
    }

}