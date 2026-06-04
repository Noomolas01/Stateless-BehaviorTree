using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;

namespace BehaviorTree.Demo.Fake
{
    internal class FakeRangeAttackCDIsFinished : AConditionNode
    {
        protected override bool Evaluate(WorldContext pWorldState, Blackboard pBlackboard)
        {
           object? lRangeCD = pBlackboard.Get("RangeCD");

            if (lRangeCD != null)
            {
                float lCD = (float)lRangeCD;
                Console.WriteLine($"Est-ce que mon attaque de melee est disponible ? {lCD <=0}");
                return lCD <= 0;
            }

            return false;
        }
    }
}