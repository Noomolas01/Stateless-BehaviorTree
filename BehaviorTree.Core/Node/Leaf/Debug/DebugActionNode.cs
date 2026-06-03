
using BehaviorTree.Core.Node.Abstract;

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

        protected override TickResult Do()
        {
            Console.WriteLine($"(ACTION){name}: {_debugResult}");
            return new TickResult(_debugResult, null);
        }
    }
}
