using BehaviorTree.Core.Node.Leaf.Abstract;
using BehaviorTree.Core.Tree.Blackboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTree.Demo.Fake.Conditions
{
    internal class AttackCondition : AConditionNode
    {
        public AttackCondition() 
        {
            name = typeof(AttackCondition).Name;
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
