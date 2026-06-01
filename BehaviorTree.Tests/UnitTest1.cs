using BehaviorTree.Core;
using BehaviorTree.Core.Composite;
using BehaviorTree.Core.Leaf;
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
        selector.Add(new ConditionNode(Result.FAILURE));
        selector.Add(new ConditionNode(Result.SUCCESS));
        Assert.That(selector.Tick(), Is.EqualTo(Result.SUCCESS));
    }

    [Test]
    public void Selector_All_Child_Failure_Should_Return_Failure()
    {
        Selector selector = new();
        selector.Add(new ConditionNode(Result.FAILURE));
        selector.Add(new ConditionNode(Result.FAILURE));
        Assert.That(selector.Tick(), Is.EqualTo(Result.FAILURE));
    }

     [Test]
        public void Selector_Any_Child_Running_Should_Return_Running()
    {
        Selector selector = new();
        selector.Add(new ConditionNode(Result.FAILURE));
        selector.Add(new ConditionNode(Result.RUNNING));
        Assert.That(selector.Tick(), Is.EqualTo(Result.RUNNING));
    }
}