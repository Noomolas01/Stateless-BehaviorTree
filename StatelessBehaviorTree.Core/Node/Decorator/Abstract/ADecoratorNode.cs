// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using StatelessBehaviorTree.Core.Node.Abstract;
using StatelessBehaviorTree.Core.Tree.Blackboard;
using StatelessBehaviorTree.Core.Tree.Interfaces;
using StatelessBehaviorTree.Core.Tree.Results;

namespace StatelessBehaviorTree.Core.Node.Decorator.Abstract
{
    internal abstract class ADecorator : ARuntimeNode
    {
        protected ARuntimeNode? child;

        public void Init(ARuntimeNode pChild)
        {
            child = pChild;
        }

        protected abstract TickResult Decorate(ARuntimeNode pNode, Blackboard pWorldContext, Blackboard pMemory);

        public override TickResult Tick(Blackboard pWorldContext, Blackboard pMemory, ITickHook? pTickObserver = null)
        {
            return Decorate(child!, pWorldContext, pMemory);
        }
    }
}