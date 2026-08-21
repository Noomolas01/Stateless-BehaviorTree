// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Node.Abstract;
using System;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using BehaviorTree.Core.Node.Composite.Interfaces;
using BehaviorTree.Core.Node.Composite.Abstract;
using BehaviorTree.Core.Tree.Interfaces;

namespace BehaviorTree.Core.Node.Composite
{
    public class Selector : AComposite
    {
    

        public Selector(string pName = "") : base(pName)
        {
        }

        public override TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickObserver = null)
        {
            for (int i = lastChildrenIndex; i < Children.Count; i++)
            {
                currentChild = Children[i];

                pTickObserver?.OnTickStart(currentChild);
                TickResult lCurrentChildResult = currentChild.Tick(pWorldContext, pMemory, pTickObserver);
                pTickObserver?.OnTickEnd(currentChild, lCurrentChildResult);

                if (lCurrentChildResult.status == NodeStatus.SUCCESS)
                {
                    lastChildrenIndex = 0;
                    return lCurrentChildResult;
                }

                else if (lCurrentChildResult.status == NodeStatus.RUNNING)
                {
                    lastChildrenIndex = i;
                    return lCurrentChildResult;
                }
            }
         
            lastChildrenIndex = 0;
            return new TickResult(NodeStatus.FAILURE, null, pMemory);
        }

   

        public override TickResult Tick(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickOberver = null)
        {
            return ProcessChildren(pWorldContext, pMemory, pTickOberver);
        }
    }
}
