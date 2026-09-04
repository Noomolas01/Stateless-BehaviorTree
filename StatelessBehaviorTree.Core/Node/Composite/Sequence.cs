// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using StatelessBehaviorTree.Core.Node.Abstract;
using StatelessBehaviorTree.Core.Node.Composite.Abstract;
using StatelessBehaviorTree.Core.Tree.Blackboard;
using StatelessBehaviorTree.Core.Tree.Interfaces;
using StatelessBehaviorTree.Core.Tree.Results;
using System;

namespace StatelessBehaviorTree.Core.Node.Composite
{
    /// <summary>
    /// Composite node that stops processing when a child returns FAILURE
    /// </summary>
    public class Sequence : AComposite
    {
        public Sequence(string pName = "") : base(pName) { }

        public override TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory, ITickHook? pTickObserver = null)
        {
            var lData = dataByBlackboard.GetValue(pMemory, _ => new CompositeData());
            
            for (int i = lData.lastChildrenIndex; i < Children.Count; i++)
            {
                ANode lCurrentChild = Children[i];

                pTickObserver?.OnTickStart(lCurrentChild);
                TickResult lCurrentChildResult = lCurrentChild.Tick(pWorldContext, pMemory, pTickObserver);
                pTickObserver?.OnTickEnd(lCurrentChild, lCurrentChildResult);

                if (lCurrentChildResult.status == NodeStatus.FAILURE)
                {
                    lData.lastChildrenIndex = 0;
                    return lCurrentChildResult;
                }

                else if (lCurrentChildResult.status == NodeStatus.RUNNING)
                {
                    lData.lastChildrenIndex = i;
                    return lCurrentChildResult;
                }
            }

            lData.lastChildrenIndex = 0;
            return new TickResult(NodeStatus.SUCCESS, null, pMemory);
        }

        public override TickResult Tick(Blackboard pWorldContext, Blackboard pMemory, ITickHook? pTickOberver = null)
        {
            return ProcessChildren(pWorldContext, pMemory, pTickOberver);
        }
    }

}