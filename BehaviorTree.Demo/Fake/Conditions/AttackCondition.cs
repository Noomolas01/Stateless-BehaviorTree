using BehaviorTree.Core.Node.Leaf.Abstract;
using BehaviorTree.Core.Tree.Blackboard;

namespace BehaviorTree.Demo.Fake.Conditions
{
    internal class AttackCondition : AConditionNode
    {
        public AttackCondition() : base("AttackCondition") 
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
