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
using BehaviorTree.Core.Tree.Results;
using System.Text;

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
        NodeStatus.INACTIVE => new Style(foreground: Color.Gray11),
        NodeStatus.SUCCESS => new Style(foreground: Color.Green),
        NodeStatus.RUNNING => new Style(foreground: Color.Yellow),
        NodeStatus.FAILURE => new Style(foreground: Color.Red),
        _ => new Style(),
    };

    var lSubTree = pRoot.AddNode(new Markup(pDebugNode.id, lStyle));

    if (pDebugNode.children == null || pDebugNode.children.Count == 0)
        return lSubTree;

    foreach (var n in pDebugNode.children)
    {
        Build(lSubTree, n);
    }

    return lSubTree;
}

#endregion

const int DELTA_TIME_MS = 500;
const float TIME_BETWEEN_TICK_IN_SEC = .5f;

BT lSimpleCombatTree = new BT.Builder()
                 .Sequence("Combat Tree (Sequence)")
                    .Condition(new AttackCondition())
                    .Action(new DoAttack())
                .End()
            .Build();


Entity lAgent_A = new("A");
DebugTree lDebug = new(lSimpleCombatTree, lAgent_A.Memory);

lAgent_A.aiComponent.Init(lDebug, TIME_BETWEEN_TICK_IN_SEC, lAgent_A.Memory);

Stopwatch lStopwatch = new();
lStopwatch.Start();

int i = 0;

StringBuilder lPresentationTextBuilder = new();

lPresentationTextBuilder.AppendLine()
                        .AppendLine($"The program draws a frame every [green]{(float)DELTA_TIME_MS / 1000}[/] seconds.")
                        .AppendLine($"[orange1]Combat component[/] handles attacks and is [green]time-based[/].")
                        .AppendLine($"Attacks are available every [green]{lAgent_A.combatComponent.attackCooldownInSec} seconds[/]")
                        .AppendLine($"Attacks take [green]{lAgent_A.combatComponent.attackDurationInSec} seconds[/] to complete")
                        .AppendLine()
                        .AppendLine($"[SpringGreen1]AI Component[/] handles decision and is [IndianRed_1]tick-based[/].")
                        .AppendLine($"[SpringGreen1]AI Component[/] ticks every [green]{TIME_BETWEEN_TICK_IN_SEC} second(s)[/].");
while (true)
{
    #region Rendering

    AnsiConsole.Write("=== Behavior Tree Demo===\n\n");

    Panel lPresentationPanel = new(lPresentationTextBuilder.ToString())
    {
        Header = new PanelHeader("What is happening ?"),
        Border = BoxBorder.Heavy
    };

    AnsiConsole.Write(lPresentationPanel);

    Text lMemoryText = new(lDebug.GetMemory());
    lMemoryText.Justify(Justify.Center);

    Panel lMemoryPanel = new(lMemoryText)
    {
        Header = new("=== Entity A's Memory ==="),
        Width = 40,
    };

    AnsiConsole.Write(lMemoryPanel);
    #endregion

    lAgent_A.Update(DELTA_TIME_MS / 1000.0f);

    #region Rendering
    AnsiConsole.Write(new Markup($"[Aquamarine1]Frame n°{i + 1}[/]\n"));
    AnsiConsole.Write(new Markup($"Program started [green]{lStopwatch.ElapsedMilliseconds / 1000} second(s)[/] ago\n"));
    Panel lPanel = new(CreateVisualTree(lDebug.root))
    {
        Header = new("Entity A's AI Component"),
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




