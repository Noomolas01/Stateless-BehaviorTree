// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================


using Spectre.Console;
using BehaviorTree.Debug;
using BehaviorTree.Demo.Fake;
using BehaviorTree.Demo.Fake.Actions;
using BT = BehaviorTree.Core.Tree.BehaviorTree;
using BehaviorTree.Demo.Fake.Conditions;
using System.Diagnostics;

#region Rendering functions
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

#endregion

BT lSimpleCombatTree = new BT.Builder()
                 .Sequence("Combat Tree (Sequence)")
                    .Condition(new AttackCondition())
                    .Action(new DoAttack())
                .End()
            .Build();

Entity lAgent_A = new("A");
DebugTree lDebug = new(lSimpleCombatTree, lAgent_A.Memory);

const int DELTA_TIME_MS = 500;
lAgent_A.aiComponent.Init(lDebug, 1f, lAgent_A.Memory);

int i = 0;

Stopwatch lStopwatch = new();
lStopwatch.Start();

while (true)
{
    #region Rendering
    

    Text lMemoryText = new(lDebug.GetMemory());
    lMemoryText.Justify(Justify.Center);

    Panel lMemoryPanel = new(lMemoryText)
    {
        Header = new("=== Memory Debug ==="),
        Width = 40,
    };

    AnsiConsole.Write(lMemoryPanel);
    #endregion
  
    lAgent_A.Update(DELTA_TIME_MS / 1000.0f);
    AnsiConsole.Write($"Frame n°{i + 1}\n");
    AnsiConsole.Write(new Text($"Program Started {lStopwatch.ElapsedMilliseconds / 1000} second(s) ago\n"));
    #region Rendering
    Panel lPanel = new(CreateVisualTree(lDebug.root))
    {
        Header = new("Entity A"),
        BorderStyle = new Style(Color.SpringGreen1),
        Expand = false,
        Width = 40
    };
    
    AnsiConsole.Write(lPanel);
    #endregion

    lDebug.Clean();
    Thread.Sleep(DELTA_TIME_MS);
    AnsiConsole.Clear();
    i++;
}




