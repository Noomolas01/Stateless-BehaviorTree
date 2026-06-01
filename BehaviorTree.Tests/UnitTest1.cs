using BehaviorTree.Core;
namespace BehaviorTree.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void Addition_Test()
    {
        Test test = new Test();
        Assert.That(test.Add(2,1), Is.EqualTo(3));
    }
}