// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using StatelessBehaviorTree.Core.Node.Abstract;
using StatelessBehaviorTree.Core.Node.Composite.Abstract;
using StatelessBehaviorTree.Core.Tree.Data;
using StatelessBehaviorTree.Core.Tree.Interfaces;
using StatelessBehaviorTree.Core.Tree.Results;

namespace StatelessBehaviorTree.Core.Node.Composite
{
    /// <summary>
    /// Composite node that stops processing when a child returns FAILURE
    /// </summary>
    public class Sequence : AComposite
    {
        public Sequence(string pName = "", bool pIsRoot = false) : base(pName, pIsRoot) { }

        public override TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory, ITickHook? pTickHook = null)
        {
            var lData = dataByBlackboard.GetValue(pMemory, _ => new CompositeData());
            
            for (int i = lData.lastChildrenIndex; i < Children.Count; i++)
            {
                ARuntimeNode lCurrentChild = Children[i];

                TickResult lCurrentChildResult = lCurrentChild.Tick(pWorldContext, pMemory, pTickHook);

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

       
    }

}