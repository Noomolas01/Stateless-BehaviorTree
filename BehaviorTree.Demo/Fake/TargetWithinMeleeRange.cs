using BehaviorTree.Core;
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;

namespace BehaviorTree.Demo.Fake
{
    internal class FakeTargetWithinMeleeRange : AConditionNode
    {
        protected override bool Evaluate(WorldContext pWorldState, Blackboard pBlackboard)
        {
            object? lTarget = pBlackboard.Get("Target");

            if (lTarget != null)
            {
                //FakePlayer player = (FakePlayer)lTarget;
                Random random = new();
                float lRandomDistance = (float)random.NextDouble();

                return lRandomDistance > .5f;
            }

            return false;
        }
    }
}