using BehaviorTree.Core;
using BehaviorTree.Core.Node.Leaf.Debug;
using BehaviorTree.Core.Tree.DataManagement;
using BT = BehaviorTree.Core.Tree.BehaviorTree;
namespace BehaviorTree.Tests;

public class UnitTestBuilder
{
    private Blackboard bb;
    private WorldContext ws;
    [SetUp]
    public void Setup()
    {
        bb = new();
        ws = new();
    }

    [Test]
    public void Build_Selector_Two_Conditions_Should_Return_Success()
    {
        BT lBrain = new BT.Builder()
                            .Selector()
                              .Condition(new DebugConditionNode(true, "C1"))
                              .Condition(new DebugConditionNode(true, "C2"))
                            .End()
                          .Build();

        Assert.That(lBrain.Tick(ws, bb).status, Is.EqualTo(NodeStatus.SUCCESS));

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

        Assert.That(lBrain.Tick(ws, bb).status, Is.EqualTo(NodeStatus.SUCCESS));

    }
}
