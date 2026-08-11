// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Node.Leaf.Abstract;
using BehaviorTree.Core.Tree.Blackboard;
using System.Text;


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

        protected override bool Evaluate(Blackboard pWorldContext, Blackboard pMemory)
        {
            Console.WriteLine($"(COND){name}: {_FakeResult}");
            return _FakeResult;
        }

    }
}