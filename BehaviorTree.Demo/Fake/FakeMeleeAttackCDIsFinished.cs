using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;

namespace BehaviorTree.Demo.Fake
{
    internal class FakeMeleeAttackCDIsFinished : AConditionNode
    {
        protected override bool Evaluate(WorldContext pWorldState, Blackboard pBlackboard)
        {
            object? lIsMeleeReady = pBlackboard.Get("MeleeIsReady");

            if (lIsMeleeReady != null)
            {
                Console.WriteLine($"Est-ce que mon attaque de melee est disponible ? {(bool)lIsMeleeReady}");
                return (bool)lIsMeleeReady;
            }

            return false;
        }
    }
}