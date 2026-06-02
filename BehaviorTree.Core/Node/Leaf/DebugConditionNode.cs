
using BehaviorTree.Core.Node.Abstract;

namespace BehaviorTree.Core.Node.Leaf;

public class DebugConditionNode : AConditionNode
{
    private readonly bool _FakeResult;

    public DebugConditionNode(bool pResult, string pName = "") : base(pName)
    {
        _FakeResult = pResult;
        name = pName;
    }

    protected override bool Evaluate()
    {
        Console.WriteLine($"(COND){name}: {_FakeResult}");
        return _FakeResult;
    }
}
