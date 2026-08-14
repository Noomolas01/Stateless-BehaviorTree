// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Node.Leaf.Debug;
using BehaviorTree.Core.Tree.Blackboard;
using BT = BehaviorTree.Core.Tree.BehaviorTree;

using Spectre.Console;
using System.Text;
using BehaviorTree.Debug;


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

//BT lSubTree = new BT.Builder()
//                .Sequence("Sub Tree Sequence")
//                    .Sequence()
//                    .End()
//                .End()
//                .Build();

Blackboard lMemory = new();
lMemory.Set("DebugOutput", new StringBuilder());
DebugTree lDebug = new(lTest, lMemory);
Thread.Sleep(3000);

Tree CreateVisualTree(DebugNode pNode)
{
    var lVisualTree = new Tree("Behavior tree");
    var lRoot = lVisualTree.AddNode("Root");
    Build(lRoot, pNode);
    //AnsiConsole.Write(lVisualTree);

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

int i = 0;
while (true)
{
    lTest.Tick(null!, lMemory, lDebug);
    // lDebug.Traverse();
    Console.WriteLine(lDebug.GetMemory());
    lMemory.Get("DebugOutput", out StringBuilder sb);
    Panel lPanel = new(CreateVisualTree(lDebug.root));
    lPanel.BorderStyle(new Style(Color.SpringGreen1));
    lPanel.Header = new($"=== Tick n°{i + 1} ===\n");
    AnsiConsole.Write(lPanel);
    Thread.Sleep(1000);
    sb.Clear();
    AnsiConsole.Clear();
    i++;
}




