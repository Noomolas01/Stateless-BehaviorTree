namespace BehaviorTree.Core.Leaf;

public class ConditionNode(Result pResult) : ANode
{
    private readonly Result _debugResult = pResult;

    public override Result Tick()
    {
        Console.WriteLine("Do Condition");
        return _debugResult;
    }
}
