using BehaviorTree.Core;
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;

namespace BehaviorTree.Demo.Fake
{
    internal class FakeMeleeAttack : AActionNode
    {
        protected override TickResult Do(WorldContext pWorldState, Blackboard pBlackboard)
        {
            if (!HasStarted)
            {
                Console.WriteLine("Je commence à attaquer");
                return new TickResult(NodeStatus.RUNNING, new AttackDecision(AttackType.MELEE));
            }

            object? lResult = pBlackboard.Get("MeleeAttackFinished");

            if (lResult != null && ((bool)lResult))
            {
                Console.WriteLine("J'ai réussi mon attaque");

                return new TickResult(NodeStatus.SUCCESS, null);
            }


            return new TickResult(NodeStatus.RUNNING, new AttackDecision(AttackType.MELEE));

        }
    }
}