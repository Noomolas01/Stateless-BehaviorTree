using StatelessBehaviorTree.Core.Node.Leaf.Abstract;
using StatelessBehaviorTree.Core.Tree.Blackboard;

namespace StatelessBehaviorTree.Demo.Fake.Conditions
{
    internal class AttackCondition : AConditionNode
    {
        public AttackCondition() :base("AttackCondition")
        {
           
        }

        protected override bool Evaluate(Blackboard pWorldContext, Blackboard pMemory)
        {
            if (!pMemory.TryGet("IsAttackReady", out bool lIsReady))
            {
                throw new Exception("Key IsAttackReady is not in memory");
            }

            return lIsReady;
        }
    }
}
