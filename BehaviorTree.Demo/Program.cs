using BehaviorTree.Core.Node.Leaf;
using BT = BehaviorTree.Core.Tree.BehaviorTree;

BT lBehaviorTree = new BT.Builder()
                   .Sequence()
                   .Action(new MoveAction())
                   .Build();

Console.WriteLine(lBehaviorTree.Tick());