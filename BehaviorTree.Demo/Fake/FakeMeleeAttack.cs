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
                Console.WriteLine("Je décide d'attaquer en mélée");
                HasStarted = true;
                return new TickResult(NodeStatus.RUNNING, new AttackDecision(AttackType.MELEE));
            }

            object? lResult = pBlackboard.Get("MeleeAttackFinished");

            if (lResult != null && ((bool)lResult))
            {
                Console.WriteLine("J'ai réussi mon attaque de mélée");
                pBlackboard.Set("MeleeAttackFinished", false);
                HasStarted = false;
                return new TickResult(NodeStatus.SUCCESS, null);
            }

            Console.WriteLine("Attaque de melee toujours en cours");
            // peut être mettre la décision d'attack en null
            return new TickResult(NodeStatus.RUNNING, new AttackDecision(AttackType.MELEE));

            

        }
    }
}