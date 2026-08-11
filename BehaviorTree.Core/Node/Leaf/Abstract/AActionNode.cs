// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;

namespace BehaviorTree.Core.Node.Leaf.Abstract
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