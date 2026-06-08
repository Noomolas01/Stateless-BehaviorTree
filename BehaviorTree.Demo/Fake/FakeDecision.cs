using System;
using BehaviorTree.Core.Struct;

namespace BehaviorTree.Core;

public readonly struct MoveDecision(Vector2 pDestination) : IAIDecision
{
    public readonly Vector2 destination = pDestination;
}

public enum AttackType
{
    MELEE,
    RANGE
}
public readonly struct AttackDecision(AttackType pAttackType) : IAIDecision
{
    public readonly AttackType attackType = pAttackType;
}
