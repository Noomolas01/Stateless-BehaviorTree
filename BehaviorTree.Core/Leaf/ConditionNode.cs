namespace BehaviorTree.Core.Leaf;

public class ConditionNode : ANode
{
    private readonly Result _debugResult;

    public ConditionNode(Result pResult, string pName) : base(pName)
    {
        _debugResult = pResult;
        Name = pName;
    }
    public override Result Tick()
    {
        Console.WriteLine("Do Condition");
        return _debugResult;
    }
}
