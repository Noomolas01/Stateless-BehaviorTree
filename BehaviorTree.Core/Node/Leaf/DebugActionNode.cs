
using BehaviorTree.Core.Node.Abstract;

namespace BehaviorTree.Core.Node.Leaf
{
    public class DebugActionNode : ANode
    {
        private readonly Result _debugResult;

        public DebugActionNode(Result pResult, string pName = "") : base(pName)
        {
            _debugResult = pResult;
            name = pName;
        }

        private Result Do()
        {
            return _debugResult;
        }

        public override Result Tick()
        {
            Console.WriteLine($"(ACTION){name}: {_debugResult}");
            return _debugResult;
        }
    }
}