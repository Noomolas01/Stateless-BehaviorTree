using BehaviorTree.Core.Struct;

namespace BehaviorTree.Core;

public interface IAIDecision;

public class MoveDecision(Vector2 pDestination) : IAIDecision
{
    public readonly Vector2 destination = pDestination;


}