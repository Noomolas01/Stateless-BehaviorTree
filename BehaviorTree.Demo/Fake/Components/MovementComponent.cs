using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using BehaviorTree.Demo.Fake.Decisions;
using System.Numerics;

namespace BehaviorTree.Demo.Fake.Components
{
    internal class MovementComponent : AComponent
    {
        private Vector3 currentPos;
        private Vector3 destination;

        public MovementComponent(Blackboard pMemory) : base(pMemory)
        {
        }

        public override void OnDecision(IAIDecision pAIDecision)
        {
            if (pAIDecision is not MovementDecision lMovementDecision)
                return;

            if (_isBusy)
                return;

            _isBusy = true;

            // Here intialize movement logic...
            Console.WriteLine("Received a Movement Decision");

            //destination = lMovementDecision.destination;
            
            
        }

        public override void Update(float pDeltaTime)
        {
            // Here handle movement logic
        }
    }
}
