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
                .Sequence()    
                    .Append(lMoveTree)
                    .Action(new DebugActionNode(BehaviorTree.Core.NodeStatus.SUCCESS, "Test"), new Repeat(2))
            .Build();

Console.WriteLine(lTest.Tick(new Blackboard(), new Blackboard()).status);

