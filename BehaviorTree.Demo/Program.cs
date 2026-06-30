using BehaviorTree.Core.Node.Leaf;
using BehaviorTree.Core.Node.Leaf.Debug;
using BehaviorTree.Core.Tree.DataManagement;
using BT = BehaviorTree.Core.Tree.BehaviorTree;




BT lMoveTree = new BT.Builder()
                .Sequence()
                    .Condition(new DebugConditionNode(true, "CanMove?"))
                    .Action(new DebugActionNode(BehaviorTree.Core.NodeStatus.SUCCESS, "Move"))
                .End()
                .Build();

BT lTest = new BT.Builder()
                .Sequence()    
                    .Append(lMoveTree)
                    .Action(new DebugActionNode(BehaviorTree.Core.NodeStatus.SUCCESS, "Test"), new Repeat(2))
            .Build();

Console.WriteLine(lTest.Tick(new Blackboard(), new Blackboard()).status);

