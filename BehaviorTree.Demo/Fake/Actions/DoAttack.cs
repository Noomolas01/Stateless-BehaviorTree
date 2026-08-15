using BehaviorTree.Core.Node.Leaf.Abstract;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using BehaviorTree.Demo.Fake.Decisions;


namespace BehaviorTree.Demo.Fake.Actions
{
    internal class DoAttack : AActionNode
    {
        public DoAttack(string pName ="DoAttack") :base(pName) { }

        protected override TickResult Do(Blackboard pWorldContext, Blackboard pMemory)
        {
            if (!pMemory.Get("AttackStarted", out bool hasStarted))
                throw new Exception("Key AttackStarted is not in memory");

            if (!pMemory.Get("AttackFinished", out bool hasFinished))
                throw new Exception("Key AttackFinished is not in memory");


            if (hasStarted && hasFinished)
            {
                pMemory.Set("AttackFinished", false);
                pMemory.Set("AttackStarted", false);
                return new TickResult(Core.NodeStatus.SUCCESS, null, pMemory);
            }

            pMemory.Set("AttackStarted", true);
            return new TickResult(Core.NodeStatus.RUNNING, new CombatDecision(), pMemory);

        }
    }
}
