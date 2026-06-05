using BehaviorTree.Core;
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;

namespace BehaviorTree.Demo.Fake
{
    internal class FakeIdle : AActionNode
    {
        protected override TickResult Do(WorldContext pWorldState, Blackboard pBlackboard)
        {
            Console.WriteLine("J'attends et danse la zumba");
            return new TickResult(NodeStatus.SUCCESS, null);
        }
    }
}