// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using StatelessBehaviorTree.Core.Node.Leaf.Abstract;
using StatelessBehaviorTree.Core.Tree.Blackboard;
using System.Text;


namespace StatelessBehaviorTree.Core.Node.Leaf.Debug
{
    public class DebugConditionNode : AConditionNode
    {
        private readonly bool _FakeResult;

        public DebugConditionNode(bool pResult, string pName = "") : base(pName)
        {
            _FakeResult = pResult;
        }

        protected override bool Evaluate(Blackboard pWorldContext, Blackboard pMemory)
        {
            pMemory.TryGet("DebugOutput", out StringBuilder sb);
            string lOutput = $"(COND){name}: {_FakeResult}\n";

            sb.AppendLine(lOutput);
            return _FakeResult;
        }

    }
}