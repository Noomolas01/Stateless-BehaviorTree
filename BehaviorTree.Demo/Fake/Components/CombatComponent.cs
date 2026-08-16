using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using BehaviorTree.Demo.Fake.Decisions;
using System;

namespace BehaviorTree.Demo.Fake.Components
{
    internal class CombatComponent : AComponent
    {
        private int _frameCount;
        private int _attackDurationInFrame = 5;
        private int _attackCooldownInFrame = 10;

        private int _currentCooldown;

        public CombatComponent(Blackboard pMemory) : base(pMemory)
        {
            // Init
            pMemory.Set("AttackFinished", false);
            pMemory.Set("AttackStarted", false);
            memory.Set("IsAttackReady", false);

        }

        public override void OnDecision(IAIDecision pAIDecision)
        {
            if (pAIDecision is not CombatDecision lCombatDecision)
                return;

            if (_isBusy)
                return;

            _isBusy = true;

            // Here initialize combat logic... 
            Console.WriteLine("Received a Combat Decision");
        }

        public override void Update(float pDeltaTime)
        {
            if (_currentCooldown < _attackCooldownInFrame)
            {
                Console.WriteLine("Attack is not ready yet");
                _currentCooldown++;
                return;
            }

            else
            {
               memory.Set("IsAttackReady", true);

            }
            // Here handle combat logic...
            _frameCount++;
            Console.WriteLine("Attack is processing...");

            // When component has finished its job, it writes in the Memory how it went
            if (_frameCount >= _attackDurationInFrame)
            {
                memory.Set("AttackFinished", true);
                Console.WriteLine("Attack is done");
                memory.Set("IsAttackReady", false);
                _frameCount = 0;
                _currentCooldown = 0;
                _isBusy = false;
            }
        }
    }
}
