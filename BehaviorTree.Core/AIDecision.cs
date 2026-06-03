using System.Numerics;

namespace BehaviorTree.Core;

public interface IAIDecision;

public class MoveDecision : IAIDecision
{
    public readonly Vector2 destination;
}