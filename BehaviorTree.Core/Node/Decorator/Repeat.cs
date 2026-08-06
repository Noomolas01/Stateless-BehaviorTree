using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Decorator.Abstract;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;

namespace BehaviorTree.Core.Node.Decorator
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