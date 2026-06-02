using BehaviorTree.Core;
using BehaviorTree.Core.Node.Composite;
using BehaviorTree.Core.Node.Leaf;
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
        selector.Add(new DebugConditionNode(Result.FAILURE));
        selector.Add(new DebugConditionNode(Result.SUCCESS));
        Assert.That(selector.Tick(), Is.EqualTo(Result.SUCCESS));
    }

    [Test]
    public void Selector_All_Child_Failure_Should_Return_Failure()
    {
        Selector selector = new();
        selector.Add(new DebugConditionNode(Result.FAILURE));
        selector.Add(new DebugConditionNode(Result.FAILURE));
        Assert.That(selector.Tick(), Is.EqualTo(Result.FAILURE));
    }

    [Test]
    public void Selector_Any_Child_Running_Should_Return_Running()
    {
        Selector selector = new();
        selector.Add(new DebugConditionNode(Result.FAILURE));
        selector.Add(new DebugConditionNode(Result.RUNNING));
        Assert.That(selector.Tick(), Is.EqualTo(Result.RUNNING));
    }


    [Test]
    public void Sequence_All_Child_Success_Should_Return_Success()
    {
        Sequence lSequence = new();
        lSequence.Add(new DebugConditionNode(Result.SUCCESS));
        lSequence.Add(new DebugConditionNode(Result.SUCCESS));

        Assert.That(lSequence.Tick(), Is.EqualTo(Result.SUCCESS));
    }

    [Test]
    public void Sequence_Any_Child_Failure_Should_Return_Failure()
    {
        Sequence lSequence = new();
        lSequence.Add(new DebugConditionNode(Result.SUCCESS));
        lSequence.Add(new DebugConditionNode(Result.SUCCESS));
        lSequence.Add(new DebugConditionNode(Result.FAILURE));
        lSequence.Add(new DebugConditionNode(Result.SUCCESS));

        Assert.That(lSequence.Tick(), Is.EqualTo(Result.FAILURE));
    }

    [Test]
    public void Sequence_All_Child_Failure_Should_Return_Failure()
    {
        Sequence lSequence = new();
        lSequence.Add(new DebugConditionNode(Result.FAILURE));
        lSequence.Add(new DebugConditionNode(Result.FAILURE));

        Assert.That(lSequence.Tick(), Is.EqualTo(Result.FAILURE));
    }

    [Test]
    public void Sequence_Any_Child_Running_Should_Return_Running()
    {
        Sequence lSequence = new();
        lSequence.Add(new DebugConditionNode(Result.SUCCESS));
        lSequence.Add(new DebugConditionNode(Result.RUNNING));

        Assert.That(lSequence.Tick(), Is.EqualTo(Result.RUNNING));
    }
}