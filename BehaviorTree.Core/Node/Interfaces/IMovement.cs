using BehaviorTree.Core.Struct;
namespace BehaviorTree.Core.Node.Interfaces;

public interface IMovement
{
    public void MoveTo(Vector2 pTarget);
    public float DistanceTo(Vector2 pTarget);
    public bool DestinationReached();
}
