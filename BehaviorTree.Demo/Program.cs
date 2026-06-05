using BehaviorTree.Core.Node.Leaf;
using BehaviorTree.Demo.Fake;
using BT = BehaviorTree.Core.Tree.BehaviorTree;

FakeAI fakeAI = new();

// Fake GameLoop
for (int i = 0; i < 50; i++)
{
    Console.WriteLine($"--Frame n°{i + 1} start--");
    fakeAI.FakeUpdate(i);
    Console.WriteLine($"--Frame n°{i + 1} end--");
}
