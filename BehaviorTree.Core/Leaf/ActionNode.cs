namespace BehaviorTree.Core.Leaf
{
    public class ActionNode(Result pResult) : ANode
    {
    private readonly Result _debugResult = pResult;

        public override Result Tick()
        {
            Console.WriteLine("Do Action Node");
            return _debugResult;
        }
    }
}