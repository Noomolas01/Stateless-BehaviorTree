namespace BehaviorTree.Core.Leaf
{
    public class ActionNode : ANode
    {
        private readonly Result _debugResult;

        public ActionNode(Result pResult, string pName) : base(pName)
        {
            _debugResult = pResult;
            Name = pName;
        }


        public override Result Tick()
        {
            Console.WriteLine("Do Action Node");
            return _debugResult;
        }
    }
}