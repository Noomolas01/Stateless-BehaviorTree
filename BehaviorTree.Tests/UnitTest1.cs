using BehaviorTree.Core;
using BehaviorTree.Core.Node.Composite;
using BehaviorTree.Core.Node.Leaf;
using BehaviorTree.Core.Node.Leaf.Debug;
namespace BehaviorTree.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void Selector_Any_Child_Success_Should_Return_Success()
    {
        Selector selector = new();
        selector.Add(new DebugConditionNode(false));
        selector.Add(new DebugConditionNode(true));
        Assert.That(selector.Tick().status, Is.EqualTo(NodeStatus.SUCCESS));
    }

    [Test]
    public void Selector_All_Child_Failure_Should_Return_Failure()
    {
        Selector selector = new();
        selector.Add(new DebugConditionNode(false));
        selector.Add(new DebugConditionNode(false));
        Assert.That(selector.Tick().status, Is.EqualTo(NodeStatus.FAILURE));
    }

    [Test]
    public void Selector_Any_Child_Running_Should_Return_Running()
    {
        Selector selector = new();
        selector.Add(new DebugConditionNode(false));
        selector.Add(new DebugActionNode(NodeStatus.RUNNING));
        Assert.That(selector.Tick().status, Is.EqualTo(NodeStatus.RUNNING));
    }


    [Test]
    public void Sequence_All_Child_Success_Should_Return_Success()
    {
        Sequence lSequence = new();
        lSequence.Add(new DebugConditionNode(true));
        lSequence.Add(new DebugConditionNode(true));

        Assert.That(lSequence.Tick().status, Is.EqualTo(NodeStatus.SUCCESS));
    }

    [Test]
    public void Sequence_Any_Child_Failure_Should_Return_Failure()
    {
        Sequence lSequence = new();
        lSequence.Add(new DebugConditionNode(true));
        lSequence.Add(new DebugConditionNode(true));
        lSequence.Add(new DebugConditionNode(false));
        lSequence.Add(new DebugConditionNode(true));

        Assert.That(lSequence.Tick().status, Is.EqualTo(NodeStatus.FAILURE));
    }

    [Test]
    public void Sequence_All_Child_Failure_Should_Return_Failure()
    {
        Sequence lSequence = new();
        lSequence.Add(new DebugConditionNode(false));
        lSequence.Add(new DebugConditionNode(false));

        Assert.That(lSequence.Tick().status, Is.EqualTo(NodeStatus.FAILURE));
    }

    [Test]
    public void Sequence_Any_Child_Running_Should_Return_Running()
    {
        Sequence lSequence = new();
        lSequence.Add(new DebugActionNode(NodeStatus.SUCCESS));
        lSequence.Add(new DebugActionNode(NodeStatus.RUNNING));

        Assert.That(lSequence.Tick().status, Is.EqualTo(NodeStatus.RUNNING));
    }
}