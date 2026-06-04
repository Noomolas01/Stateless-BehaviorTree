using BehaviorTree.Core;
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;

namespace BehaviorTree.Demo.Fake
{
    internal class FindTarget : AActionNode
    {
        protected override TickResult Do(WorldContext pWorldContext, Blackboard pBlackboard)
        {
            object? player = pWorldContext.Get("Player");

            if (player != null)
            {
                pBlackboard.Set<object?>("Target", player);
                return new TickResult(NodeStatus.SUCCESS, null);
            }

            pBlackboard.Set<object?>("Target", null);
            return new TickResult(NodeStatus.FAILURE, null);
        }
    }
}