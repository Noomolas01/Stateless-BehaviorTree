using BehaviorTree.Core.Node.Leaf.Abstract;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using BehaviorTree.Demo.Fake.Decisions;


namespace BehaviorTree.Demo.Fake.Actions
{
    internal class DoMovement : AActionNode
    {
        public DoMovement() : base("DoMovement")
        {
            
        }

        protected override TickResult Do(Blackboard pWorldContext, Blackboard pMemory)
        {
            if (!pMemory.TryGet("MovementStarted", out bool hasStarted))
                throw new Exception("Key MovementStarted is not in memory");

            if (!pMemory.TryGet("MovementFinished", out bool hasFinished))
                throw new Exception("Key MovementStarted is not in memory");


            if (hasStarted && hasFinished)
            {
                pMemory.Set("MovemementStarted", false);
                pMemory.Set("MovemementFinished", false);
                return new TickResult(NodeStatus.SUCCESS, null, pMemory);
            }

            pMemory.Set("MovementStarted", true);
            return new TickResult(NodeStatus.RUNNING, new CombatDecision(), pMemory);

        }
    }
}
