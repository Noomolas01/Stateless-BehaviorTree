// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Node.Leaf.Debug;
using BehaviorTree.Core.Tree.Blackboard;
using Spectre.Console;
using System.Text;
using BehaviorTree.Debug;
using BehaviorTree.Demo.Fake;
using BehaviorTree.Demo.Fake.Actions;
using BT = BehaviorTree.Core.Tree.BehaviorTree;
using BehaviorTree.Demo.Fake.Conditions;


BT lMoveTree = new BT.Builder()
                .Sequence("Move Sequence")
                    .Condition(new DebugConditionNode(false, "CanMove?"))
                    .Action(new DebugActionNode(BehaviorTree.Core.NodeStatus.SUCCESS, "Move Action"))
                .End()
                .Build();

BT lTest = new BT.Builder()
                .Sequence("Test Sequence")
                    .Append(lMoveTree)
                    .Action(new DebugActionNode(BehaviorTree.Core.NodeStatus.FAILURE, "Test Action"))
                    .Action(new DebugActionNode(BehaviorTree.Core.NodeStatus.SUCCESS, "Test Action 2"))
                 .End()
            .Build();


BT lCombatTree = new BT.Builder()
                .Sequence("Combat Tree")
                    .Condition(new AttackCondition())
                    .Action(new DoAttack())   
                .End()
            .Build();



Tree CreateVisualTree(DebugNode pNode)
{
    var lVisualTree = new Tree("Behavior tree");
    var lRoot = lVisualTree.AddNode("Root");
    Build(lRoot, pNode);
    return lVisualTree;
}

TreeNode Build(TreeNode pRoot, DebugNode pDebugNode)
{
    var lStyle = pDebugNode.result.status switch
    {
        BehaviorTree.Core.NodeStatus.INACTIVE => new Style(foreground: Color.Gray11),
        BehaviorTree.Core.NodeStatus.SUCCESS => new Style(foreground: Color.Green),
        BehaviorTree.Core.NodeStatus.RUNNING => new Style(foreground: Color.Yellow),
        BehaviorTree.Core.NodeStatus.FAILURE => new Style(foreground: Color.Red),
        _ => new Style(),
    };

    var lSubTree = pRoot.AddNode(new Markup(pDebugNode.id, lStyle));
    if (pDebugNode.children == null || pDebugNode.children.Count == 0)
        return lSubTree;

    foreach (var n in pDebugNode.children)
    {
        Build(lSubTree, n);
    }

    //var intermediateTree = new Tree(pDebugNode.id);
    //intermediateTree.AddNode(lSubTree);
    //var panel = new Panel(intermediateTree);
    //AnsiConsole.Write(panel);

    return lSubTree;
}

Entity lEntity_A = new("A");
DebugTree lDebug = new (lCombatTree, lEntity_A.Memory);
lEntity_A.aiComponent.Init(lDebug, 1f / 60.0f, lEntity_A.Memory);

int i = 0;
float lFakeDeltaTime = 1.0f / 60.0f;
while (true)
{
    lEntity_A.Update(lFakeDeltaTime);
    
    Console.WriteLine(lDebug.GetMemory());

    Panel lPanel = new(CreateVisualTree(lDebug.root));


    lPanel.BorderStyle(new Style(Color.SpringGreen1));
    lPanel.Header = new($"=== Tick n°{i + 1} ===\n");
    AnsiConsole.Write(lPanel);
    lDebug.Clean();
    Thread.Sleep(1000);
    
    AnsiConsole.Clear();
    i++;
}




