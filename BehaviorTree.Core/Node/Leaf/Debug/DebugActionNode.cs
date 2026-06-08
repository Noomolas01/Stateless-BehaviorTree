
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;
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

        protected override TickResult Do(WorldContext pWorldState, Blackboard pBlackboard)
        {
            Console.WriteLine($"(ACTION){name}: {_debugResult}");
            return new TickResult(_debugResult, null);
        }
    }
}
