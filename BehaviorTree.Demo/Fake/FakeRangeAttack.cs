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
            {
                HasStarted = true;
                Console.WriteLine("Je décide d'attaquer en range");

                return new TickResult(NodeStatus.RUNNING, new AttackDecision(AttackType.RANGE));
            }

            object? lResult = pBlackboard.Get("RangeAttackFinished");

            if (lResult != null && ((bool)lResult))
            {
                Console.WriteLine("J'ai réussi mon attaque de range");
                HasStarted = false;
                return new TickResult(NodeStatus.SUCCESS, null);
            }

            Console.WriteLine("Attaque de range toujours en cours");

            return new TickResult(NodeStatus.RUNNING, new AttackDecision(AttackType.RANGE));

        }
    }
}