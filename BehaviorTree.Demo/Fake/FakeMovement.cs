using BehaviorTree.Core.Node.Interfaces;
using BehaviorTree.Core.Struct;

namespace BehaviorTree.Demo.Fake;

public class FakeMovement : IMovement
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