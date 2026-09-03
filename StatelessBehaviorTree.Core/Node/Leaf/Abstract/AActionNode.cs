// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Interfaces;
using BehaviorTree.Core.Tree.Results;

namespace BehaviorTree.Core.Node.Leaf.Abstract
{
    /// <summary>
    /// Base class for action node 
    /// </summary>
    public abstract class AActionNode: ANode
    {
        public AActionNode(string pName = "") : base(pName) { }
        protected abstract TickResult Do(Blackboard pWorldContext, Blackboard pMemory);

        public override TickResult Tick(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickObserver = null)
        {
            return Do(pWorldContext, pMemory);
        }
    }

}