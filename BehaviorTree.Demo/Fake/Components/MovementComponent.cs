using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using BehaviorTree.Demo.Fake.Decisions;

namespace BehaviorTree.Demo.Fake.Components
{
    internal class MovementComponent : AComponent
    {
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

            Console.WriteLine("Received a Movement Decision");
            // Here intialize movement logic

        }

        public override void Update(float pDeltaTime)
        {
            // Here handle movement logic
        }
    }
}
