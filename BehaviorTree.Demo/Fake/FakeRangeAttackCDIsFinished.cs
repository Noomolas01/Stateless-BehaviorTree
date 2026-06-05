using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;

namespace BehaviorTree.Demo.Fake
{
    internal class FakeRangeAttackCDIsFinished : AConditionNode
    {
        protected override bool Evaluate(WorldContext pWorldState, Blackboard pBlackboard)
        {
           object? lIsRangeReady = pBlackboard.Get("RangeIsReady");

            if (lIsRangeReady != null)
            {
                bool lCD = (bool)lIsRangeReady;
                Console.WriteLine($"Est-ce que mon attaque de distance est disponible ? {lCD}");
                return lCD;
            }

            return false;
        }
    }
}