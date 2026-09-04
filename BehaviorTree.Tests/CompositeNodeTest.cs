// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using StatelessBehaviorTree.Core.Node.Composite;
using StatelessBehaviorTree.Core.Node.Leaf.Debug;
using StatelessBehaviorTree.Core.Tree.Blackboard;
using StatelessBehaviorTree.Core.Tree.Results;
using System.Text;

namespace StatelessBehaviorTree.Tests;
public class CompositeNodeTest
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
    public void Selector_Any_Child_Success_Should_Return_Success()
    {
        Selector lSelector = new();
        lSelector.Add(new DebugConditionNode(false));
        lSelector.Add(new DebugConditionNode(true));
        Assert.That(lSelector.Tick(ws, bb).status, Is.EqualTo(NodeStatus.SUCCESS));
    }

    [Test]
    public void Selector_All_Child_Failure_Should_Return_Failure()
    {
        Selector lSelector = new();
        lSelector.Add(new DebugConditionNode(false));
        lSelector.Add(new DebugConditionNode(false));
        Assert.That(lSelector.Tick(ws, bb).status, Is.EqualTo(NodeStatus.FAILURE));
    }

    [Test]
    public void Selector_Any_Child_Running_Should_Return_Running()
    {
        Selector lSelector = new();
        lSelector.Add(new DebugConditionNode(false));
        lSelector.Add(new DebugActionNode(NodeStatus.RUNNING));
        Assert.That(lSelector.Tick(ws, bb).status, Is.EqualTo(NodeStatus.RUNNING));
    }


    [Test]
    public void Sequence_All_Child_Success_Should_Return_Success()
    {
        Sequence lSequence = new();
        lSequence.Add(new DebugConditionNode(true));
        lSequence.Add(new DebugConditionNode(true));

        Assert.That(lSequence.Tick(ws, bb).status, Is.EqualTo(NodeStatus.SUCCESS));
    }

    [Test]
    public void Sequence_Any_Child_Failure_Should_Return_Failure()
    {
        Sequence lSequence = new();
        lSequence.Add(new DebugConditionNode(true));
        lSequence.Add(new DebugConditionNode(true));
        lSequence.Add(new DebugConditionNode(false));
        lSequence.Add(new DebugConditionNode(true));

        Assert.That(lSequence.Tick(ws, bb).status, Is.EqualTo(NodeStatus.FAILURE));
    }

    [Test]
    public void Sequence_All_Child_Failure_Should_Return_Failure()
    {
        Sequence lSequence = new();
        lSequence.Add(new DebugConditionNode(false));
        lSequence.Add(new DebugConditionNode(false));

        Assert.That(lSequence.Tick(ws, bb).status, Is.EqualTo(NodeStatus.FAILURE));
    }

    [Test]
    public void Sequence_Any_Child_Running_Should_Return_Running()
    {
        Sequence lSequence = new();
        lSequence.Add(new DebugActionNode(NodeStatus.SUCCESS));
        lSequence.Add(new DebugActionNode(NodeStatus.RUNNING));

        Assert.That(lSequence.Tick(ws, bb).status, Is.EqualTo(NodeStatus.RUNNING));
    }

    [Test]
    public void Add_Typed_Key_In_Blackboard_Value_Should_Be_True()
    {
        Blackboard lbb = new();
        BBKey<bool> lTestKey = new("IsAliyaHungry");
        lbb.Set(lTestKey, true);
        lbb.TryGet(lTestKey, out bool lValue);

        Assert.That(lValue, Is.EqualTo(true));
    }

 
}