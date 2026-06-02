// See https://aka.ms/new-console-template for more information


using BehaviorTree.Core.Node.Composite;
using BehaviorTree.Core.Node.Leaf;

Selector selector = new();
Sequence sequence = new();
sequence.Add(new DebugConditionNode(BehaviorTree.Core.Result.FAILURE, "C1"));
sequence.Add(new DebugActionNode(BehaviorTree.Core.Result.SUCCESS, "A1"));
sequence.Add(new DebugActionNode(BehaviorTree.Core.Result.SUCCESS, "A2"));
selector.Add(sequence);

Console.WriteLine(selector.Tick().ToString());