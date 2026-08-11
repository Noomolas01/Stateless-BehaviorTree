// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Node.Leaf.Abstract;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using System;

namespace BehaviorTree.Core.Node.Leaf.Debug
{
    public class DebugActionNode : AActionNode
    {
        private readonly NodeStatus _debugResult;

        public DebugActionNode(NodeStatus pResult, string pName = "") : base(pName)
        {
            _debugResult = pResult;
            name = pName;
        }

        protected override TickResult Do(Blackboard pWorldContext, Blackboard pMemory)
        {
            Console.WriteLine($"(ACTION){name}: {_debugResult}");
            return new TickResult(_debugResult, null, pMemory);
        }
    }
}
