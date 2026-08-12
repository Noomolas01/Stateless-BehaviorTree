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
                    .Condition(new DebugConditionNode(true, "CanMove?"))
                    .Action(new DebugActionNode(BehaviorTree.Core.NodeStatus.SUCCESS, "Move Action"))
                .End()
                .Build();

BT lTest = new BT.Builder()
                .Sequence("Test Sequence")
                    .Append(lMoveTree)
                    .Action(new DebugActionNode(BehaviorTree.Core.NodeStatus.FAILURE, "Test Action"))
                    .Action(new DebugActionNode(BehaviorTree.Core.NodeStatus.SUCCESS, "Test Action 2"))
            .Build();

DebugTree debug = new(lTest);
Blackboard memory = new();
memory.Set("DebugOutput", new StringBuilder());

//var treeVisual = new Tree("Tree Test");
//treeVisual.Style = new Style(foreground: Color.Red);
//var node1 = treeVisual.AddNode("[red]Hello[/]");
//node1.AddNode("[red]Hello Wrld[/]");
//treeVisual.AddNode("Hello");
//treeVisual.AddNode("Hello");
//AnsiConsole.Write(treeVisual);

Thread.Sleep(3000);
int i = 0;

Action<DebugNode> action = x =>
{
    //Console.WriteLine(x.id + " : " + x.result);
    //Console.WriteLine("It contains:" + debug.tree.ContainsValue(x));
};

Tree CreateVisualTree(DebugNode pNode)
{
    var lVisualTree = new Tree("Behavior tree");
    var lRoot = lVisualTree.AddNode("Root");
    Build(lRoot, pNode);
   // AnsiConsole.Write(lVisualTree);

    return lVisualTree;
}

TreeNode Build(TreeNode pRoot, DebugNode pDebugNode)
{
    Style lStyle;
    switch (pDebugNode.result.status)
    {
        case BehaviorTree.Core.NodeStatus.INACTIVE:
            lStyle = new Style(foreground: Color.Gray11);
            break;
        case BehaviorTree.Core.NodeStatus.SUCCESS:
            lStyle = new Style(foreground: Color.Green);
            break;
        case BehaviorTree.Core.NodeStatus.RUNNING:
            lStyle = new Style(foreground: Color.Yellow);
            break;
        case BehaviorTree.Core.NodeStatus.FAILURE:
            lStyle = new Style(foreground: Color.Red);
            break;
        default:
            lStyle = new Style();
            break;
    }

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

while (true)
{
    lTest.Tick(null!, memory, debug);
    //debug.Traverse();
    memory.Get("DebugOutput", out StringBuilder sb);
    Panel lPanel = new(CreateVisualTree(debug.root));
    lPanel.BorderStyle(new Style(Color.SpringGreen1));
    lPanel.Header = new($"=== Tick n°{i + 1} ===\n");
    AnsiConsole.Write(lPanel);
    Thread.Sleep(1250);
    sb.Clear();
    AnsiConsole.Clear();
    i++;
}




