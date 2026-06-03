using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Interfaces;

namespace BehaviorTree.Core.Node.Leaf;

public class MoveAction : AActionNode
{
    private readonly IMovement movement;

    protected override TickResult Do()
    {
        if (!HasStarted)
        {
            Console.WriteLine("Start Moving");
            HasStarted = true;
            movement.MoveTo(new Struct.Vector2() { X = 0, Y = 0 });
            return new TickResult(NodeStatus.RUNNING, null);
        }

        throw new NotImplementedException();

    }
}
