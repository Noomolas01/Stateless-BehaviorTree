using BehaviorTree.Core;
namespace BehaviorTree.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void ActionNode_Creation()
    {
        ActionNode node = new ActionNode();
        node.Tick();
        Assert.Pass();
    }
}