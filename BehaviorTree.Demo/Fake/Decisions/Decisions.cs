using BehaviorTree.Core.Tree.Results;
using System.Numerics;


namespace BehaviorTree.Demo.Fake.Decisions
{
    internal struct MovementDecision : IAIDecision
    {
        public Vector3 destination;
    }

    internal struct CombatDecision : IAIDecision
    {
        public string type;
    }
}
