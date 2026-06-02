
using BehaviorTree.Core.Node.Abstract;

namespace BehaviorTree.Core.Node.Leaf
{
    public class DebugActionNode : AActionNode
    {
        private readonly Result _debugResult;

        public DebugActionNode(Result pResult, string pName = "") : base(pName)
        {
            _debugResult = pResult;
            name = pName;
        }

        protected override Result Do()
        {
            Console.WriteLine($"(ACTION){name}: {_debugResult}");
            return _debugResult;
        }
    }
}
