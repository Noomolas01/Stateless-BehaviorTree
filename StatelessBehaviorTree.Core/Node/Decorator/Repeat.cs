// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using StatelessBehaviorTree.Core.Node.Abstract;
using StatelessBehaviorTree.Core.Node.Decorator.Abstract;
using StatelessBehaviorTree.Core.Tree.Blackboard;
using StatelessBehaviorTree.Core.Tree.Results;

namespace StatelessBehaviorTree.Core.Node.Decorator
{
    // WIP
    internal class Repeat : ADecorator
    {
        private readonly int _count;
        private int _current = 0;
        public Repeat(int pCount)
        {
            _count = pCount;
        }

        protected override TickResult Decorate(ANode pNode, Blackboard pWorldContext, Blackboard pMemory)
        {
            TickResult lChildTickResult;

            lChildTickResult = child!.Tick(pWorldContext, pMemory);

            if (lChildTickResult.status == NodeStatus.RUNNING)
                return lChildTickResult;

            _current++;

            throw new System.NotImplementedException();


        }
    }
}