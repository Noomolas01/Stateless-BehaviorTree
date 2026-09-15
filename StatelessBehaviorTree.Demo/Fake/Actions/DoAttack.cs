using StatelessBehaviorTree.Core.Node.Leaf.Abstract;
using StatelessBehaviorTree.Core.Tree.Blackboard;
using StatelessBehaviorTree.Core.Tree.Results;
using StatelessBehaviorTree.Demo.Fake.Decisions;


namespace StatelessBehaviorTree.Demo.Fake.Actions
{
    internal class DoAttack : AActionNode
    {
        public DoAttack(string pName = "DoAttack") : base(pName) { }

        protected override TickResult Do(Blackboard pWorldContext, Blackboard pMemory)
        {
            if (!pMemory.TryGet("AttackStarted", out bool hasStarted))
                throw new Exception("Key AttackStarted is not in memory");

            if (!pMemory.TryGet("AttackFinished", out bool hasFinished))
                throw new Exception("Key AttackFinished is not in memory");


            if (hasStarted && hasFinished)
            {
                pMemory.Set("AttackFinished", false);
                pMemory.Set("AttackStarted", false);
                return new TickResult(NodeStatus.SUCCESS, null, pMemory);
            }

            pMemory.Set("AttackStarted", true);
            return new TickResult(NodeStatus.RUNNING, new CombatDecision(), pMemory);

        }
    }
}
