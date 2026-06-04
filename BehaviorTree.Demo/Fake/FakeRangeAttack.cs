using BehaviorTree.Core;
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;

namespace BehaviorTree.Demo.Fake
{
    internal class FakeRangeAttack : AActionNode
    {
        protected override TickResult Do(WorldContext pWorldState, Blackboard pBlackboard)
        {
            if (!HasStarted)
                return new TickResult(NodeStatus.RUNNING, new AttackDecision(AttackType.RANGE));

            object? lResult = pBlackboard.Get("RangeAttackFinished");

            if (lResult != null && ((bool)lResult))
            {
                return new TickResult(NodeStatus.SUCCESS, null);
            }


            return new TickResult(NodeStatus.RUNNING, new AttackDecision(AttackType.RANGE));

        }
    }
}