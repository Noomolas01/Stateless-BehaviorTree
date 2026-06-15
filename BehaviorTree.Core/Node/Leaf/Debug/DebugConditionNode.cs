
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;
using BehaviorTree.Core.Tree.DataManagement;
using System;

namespace BehaviorTree.Core.Node.Leaf.Debug
{
    public class DebugConditionNode : AConditionNode
    {
        private readonly bool _FakeResult;

        public DebugConditionNode(bool pResult, string pName = "") : base(pName)
        {
            _FakeResult = pResult;
            name = pName;
        }

        protected override bool Evaluate(WorldContext pWorldContext, Blackboard pBlackboard)
        {
            Console.WriteLine($"(COND){name}: {_FakeResult}");
            return _FakeResult;
        }
    }
}