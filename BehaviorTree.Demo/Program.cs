using BehaviorTree.Core.Node.Leaf;
using BehaviorTree.Demo.Fake;
using BT = BehaviorTree.Core.Tree.BehaviorTree;

FakeAI fakeAI = new();


for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Tick n°{i+1} start");
    fakeAI.GetDecision();
    Console.WriteLine($"Tick n°{i+1} end");

}
