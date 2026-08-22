// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Node.Leaf.Debug;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using BehaviorTree.Demo.Fake.Conditions;
using System.Text;
using BT = BehaviorTree.Core.Tree.BehaviorTree;
namespace BehaviorTree.Tests;

public class BuilderTest
{
    private Blackboard bb;
    private Blackboard ws;
    [SetUp]
    public void Setup()
    {
        bb = new();
        ws = new();

        bb.Set("DebugOutput", new StringBuilder());
    }

    [Test]
    public void Build_Selector_Two_Conditions_Should_Return_Success()
    {
        BT lTree = new BT.Builder()
                            .Selector()
                              .Condition(new DebugConditionNode(false, "C1"))
                              .Condition(new DebugConditionNode(true, "C2"))
                            .End()
                          .Build();

        Assert.That(lTree.Tick(ws, bb).status, Is.EqualTo(NodeStatus.SUCCESS));

    }

    [Test]
    public void Build_Sequence_Two_Conditions_Should_Return_Success()
    {
        BT lTree = new BT.Builder()
                              .Sequence()
                                .Condition(new DebugConditionNode(true, "C1"))
                                .Condition(new DebugConditionNode(true, "C2"))
                              .End()
                          .Build();

        Assert.That(lTree.Tick(ws, bb).status, Is.EqualTo(NodeStatus.SUCCESS));

    }

    [Test]
    public void Share_One_Tree_With_Multiple_Blackboard()
    {
        Blackboard memory_A = new();
        Blackboard memory_B = new();

        memory_A.Set("IsAttackReady", true);
        memory_B.Set("IsAttackReady", false);

        BT lTree = new BT.Builder()
                    .Sequence()
                        .Condition(new AttackCondition())
                    .End()
                    .Build();

        Assert.That(lTree.Tick(null!, memory_A).status, Is.EqualTo(NodeStatus.SUCCESS));
        Console.WriteLine("Enity A can Attack.");
        Assert.That(lTree.Tick(null!, memory_B).status, Is.EqualTo(NodeStatus.FAILURE));
        Console.WriteLine("Enity B cannot Attack.");
    }
}
