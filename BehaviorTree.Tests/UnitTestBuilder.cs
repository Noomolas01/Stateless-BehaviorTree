using BehaviorTree.Core;
using BehaviorTree.Core.Node.Leaf.Debug;

using BT = BehaviorTree.Core.Tree.BehaviorTree;
namespace BehaviorTree.Tests;

public class UnitTestBuilder
{

    [Test]
    public void Build_Selector_Two_Conditions_Should_Return_Success()
    {
        BT lBrain = new BT.Builder()
                              .Condition(new DebugConditionNode(true, "C1"))
                              .Condition(new DebugConditionNode(true, "C2"))
                              .End()
                          .Build();

        Assert.That(lBrain.Tick().status, Is.EqualTo(NodeStatus.SUCCESS));

    }

    [Test]
    public void Build_Sequence_Two_Conditions_Should_Return_Success()
    {
        BT lBrain = new BT.Builder()
                              .Sequence()
                                .Condition(new DebugConditionNode(true, "C1"))
                                .Condition(new DebugConditionNode(true, "C2"))
                              .End()
                          .Build();

        Assert.That(lBrain.Tick().status, Is.EqualTo(NodeStatus.SUCCESS));

    }
}
