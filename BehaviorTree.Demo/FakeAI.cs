using BehaviorTree.Core;
using BehaviorTree.Core.Node.Interfaces;
using BehaviorTree.Core.Node.Leaf;
using BehaviorTree.Core.Struct;
using BehaviorTree.Core.Tree;
using BT = BehaviorTree.Core.Tree.BehaviorTree;

namespace BehaviorTree.Demo;

public class FakeAI
{
    private readonly BT _Brain;
    private readonly IMovement movementComponent = new FakeMovementComponent();

    public FakeAI()
    {
        Blackboard blackboard = new();
        WorldState worldState = new();
        
        _Brain = new BT.Builder()
                    .Action(new MoveAction())
                    .Build();

        TickResult tickResult = _Brain.Tick(worldState, blackboard);

        if (tickResult.decision is MoveDecision moveDecision)
        {
            movementComponent.MoveTo(moveDecision.destination);
        }
    }

}

public class FakeMovementComponent : IMovement
{
    public bool DestinationReached()
    {
        throw new NotImplementedException();
    }

    public float DistanceTo(Vector2 pTarget)
    {
        throw new NotImplementedException();
    }

    public void MoveTo(Vector2 pTarget)
    {
        throw new NotImplementedException();
    }
}