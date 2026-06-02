
using BehaviorTree.Core.Node.Abstract;

namespace BehaviorTree.Core.Node.Leaf;

public class DebugConditionNode : ANode
{
    private readonly Result _debugResult;

    public DebugConditionNode(Result pResult, string pName = "") : base(pName)
    {
        _debugResult = pResult;
        name = pName;
    }

    public override Result Tick()
    {
        Console.WriteLine($"(COND){name}: {_debugResult}");
        return _debugResult;
    }
}
