using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;

namespace BehaviorTree.Demo.Fake
{
    internal class FakeMeleeAttackCDIsFinished : AConditionNode
    {
        protected override bool Evaluate(WorldContext pWorldState, Blackboard pBlackboard)
        {
            object? lMeleeCD = pBlackboard.Get("MeleeCD");

            if (lMeleeCD != null)
            {
                float lCD = (float)lMeleeCD;

                return lCD <= 0;
            }

            return false;
        }
    }
}