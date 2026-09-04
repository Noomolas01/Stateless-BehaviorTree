// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using StatelessBehaviorTree.Core.Node.Leaf.Abstract;
using StatelessBehaviorTree.Core.Tree.Blackboard;
using StatelessBehaviorTree.Core.Tree.Results;
using System;
using System.Text;

namespace StatelessBehaviorTree.Core.Node.Leaf.Debug
{
    public class DebugActionNode : AActionNode
    {
        private readonly NodeStatus _debugResult;

        public DebugActionNode(NodeStatus pResult, string pName = "") : base(pName)
        {
            _debugResult = pResult;
        }

        protected override TickResult Do(Blackboard pWorldContext, Blackboard pMemory)
        {
            pMemory.TryGet("DebugOutput", out StringBuilder sb);
            string output = $"(ACTION){name}: {_debugResult}\n";
            sb.AppendLine(output);
            return new TickResult(_debugResult, null, pMemory);
        }
    }
}
