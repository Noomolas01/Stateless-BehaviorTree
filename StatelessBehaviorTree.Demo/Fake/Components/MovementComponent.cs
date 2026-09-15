using StatelessBehaviorTree.Core.Tree.Blackboard;
using StatelessBehaviorTree.Core.Tree.Results;
using StatelessBehaviorTree.Demo.Fake.Decisions;
using System.Numerics;

namespace StatelessBehaviorTree.Demo.Fake.Components
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
