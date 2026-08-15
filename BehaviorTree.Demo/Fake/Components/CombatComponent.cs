using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using BehaviorTree.Demo.Fake.Decisions;

namespace BehaviorTree.Demo.Fake.Components
{
    internal class CombatComponent : AComponent
    {
        private int _count;
        public CombatComponent(Blackboard pMemory) : base(pMemory)
        {
            // Init
            pMemory.Set("AttackFinished", false);
            pMemory.Set("AttackStarted", false);
        }

        public override void OnDecision(IAIDecision pAIDecision)
        {
            if (pAIDecision is not CombatDecision lCombatDecision)
                return;

            if (_isBusy)
                return;

            // _isBusy = true;

            // Here initialize combat logic... 
            Console.WriteLine("Received a Combat Decision");
        }

        public override void Update(float pDeltaTime)
        {
            // Here handle combat logic...
            _count++;


            // When component has finished its job, it writes in the Memory how it went
            if (_count >= 5)
            {
                memory.Set("AttackFinished", true);
                Console.WriteLine("Attack is done");
                _count = 0;
            }
        }
    }
}
