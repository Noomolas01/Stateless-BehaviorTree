using StatelessBehaviorTree.Core.Tree.Blackboard;
using StatelessBehaviorTree.Core.Tree.Results;

namespace StatelessBehaviorTree.Demo.Fake.Components
{
    internal abstract class AComponent
    {
        protected readonly Blackboard memory;
        protected bool _isBusy;

        public AComponent(Blackboard pMemory)
        {
            memory = pMemory;
        }
        public abstract void Update(float pDeltaTime);
        public abstract void OnDecision(IAIDecision pDecision);

    }
}
