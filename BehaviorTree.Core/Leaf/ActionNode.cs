namespace BehaviorTree.Core.Leaf
{
    public class ActionNode : ANode
    {
        private readonly Result _debugResult;

        public ActionNode(Result pResult, string pName = "") : base(pName)
        {
            _debugResult = pResult;
            name = pName;
        }


        public override Result Tick()
        {
            Console.WriteLine($"(ACTION){name}: {_debugResult}");
            return _debugResult;
        }
    }
}