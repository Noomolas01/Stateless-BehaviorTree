using BehaviorTree.Core;
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;

namespace BehaviorTree.Demo.Fake
{
    internal class TargetPlayer : AActionNode
    {
        protected override TickResult Do(WorldContext pWorldContext, Blackboard pBlackboard)
        {
            object? player = pWorldContext.Get("Player");

            if (player != null)
            {
                pBlackboard.Set<object?>("Target", player);
                Console.WriteLine("J'ai trouvé le joueur et pris pour cible");
                return new TickResult(NodeStatus.SUCCESS, null);
            }

            pBlackboard.Set<object?>("Target", null);
                Console.WriteLine("Je n'ai pas trouvé le joueur, je n'ai pas de cible");

            return new TickResult(NodeStatus.FAILURE, null);
        }
    }
}