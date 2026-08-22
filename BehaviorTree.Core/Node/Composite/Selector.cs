// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using BehaviorTree.Core.Node.Composite.Abstract;
using BehaviorTree.Core.Tree.Interfaces;
using BehaviorTree.Core.Node.Abstract;

namespace BehaviorTree.Core.Node.Composite
{
    public class Selector : AComposite
    {
    

        public Selector(string pName = "") : base(pName)
        {
        }

        public override TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickObserver = null)
        {

            if (!lastChildrenByBlackboard.ContainsKey(pMemory))
            {
                lastChildrenByBlackboard[pMemory] = 0;
            }

            for (int i = lastChildrenByBlackboard[pMemory]; i < Children.Count; i++)
            {
                ANode lCurrentChild = Children[i];

                pTickObserver?.OnTickStart(lCurrentChild);
                TickResult lCurrentChildResult = lCurrentChild.Tick(pWorldContext, pMemory, pTickObserver);
                pTickObserver?.OnTickEnd(lCurrentChild, lCurrentChildResult);

                if (lCurrentChildResult.status == NodeStatus.SUCCESS)
                {
                    lastChildrenByBlackboard[pMemory] = 0;
                    return lCurrentChildResult;
                }

                else if (lCurrentChildResult.status == NodeStatus.RUNNING)
                {
                    lastChildrenByBlackboard[pMemory] = i;
                    return lCurrentChildResult;
                }
            }
         
            lastChildrenByBlackboard[pMemory] = 0;
            return new TickResult(NodeStatus.FAILURE, null, pMemory);
        }

        public override TickResult Tick(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickOberver = null)
        {
            return ProcessChildren(pWorldContext, pMemory, pTickOberver);
        }
    }
}
