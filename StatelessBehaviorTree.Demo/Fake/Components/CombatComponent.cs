using StatelessBehaviorTree.Core.Tree.Blackboard;
using StatelessBehaviorTree.Core.Tree.Results;
using StatelessBehaviorTree.Demo.Fake.Decisions;
using Spectre.Console;
using System;

namespace StatelessBehaviorTree.Demo.Fake.Components
{
    internal class CombatComponent : AComponent
    {
        public readonly int attackDurationInSec = 5;
        public readonly int attackCooldownInSec = 10;

        private float _currentCooldown;
        private float _secondsSinceAttackStarted;

        private string _decisionReceivedString = new("");
        private Panel _combatComponentPanel = new("Combat Component");

        public CombatComponent(Blackboard pMemory) : base(pMemory)
        {
            // Init
            pMemory.Set("AttackFinished", false);
            pMemory.Set("AttackStarted", false);
            memory.Set("IsAttackReady", false);

            _combatComponentPanel = new("")
            {
                Header = new PanelHeader(" Combat Component Update "),
                Border = BoxBorder.Double,
                BorderStyle = new Style(foreground: Color.Orange1),
                Width = 40
            };

        }

        public override void OnDecision(IAIDecision pAIDecision)
        {
            if (pAIDecision is not CombatDecision lCombatDecision)
                return;

            if (_isBusy)
                return;

            _isBusy = true;

            // Here initialize combat logic... 
            _decisionReceivedString = "Received a Combat Decision";

        }

        public override void Update(float pDeltaTime)
        {
            string lIsAttackReadyText = string.Empty;

            if (_currentCooldown < attackCooldownInSec)
            {
                lIsAttackReadyText = "Attack is not ready yet";
                _currentCooldown += pDeltaTime;
                return;
            }

            else
            {

                memory.Set("IsAttackReady", true);

                // Here handle combat logic...
                _secondsSinceAttackStarted += pDeltaTime;
                string lIsAttackProcessingText = "Attack is processing...";

                // When component has finished its job, it writes in the Memory how it went
                if (_secondsSinceAttackStarted >= attackDurationInSec)
                {
                    memory.Set("AttackFinished", true);
                    lIsAttackProcessingText = "Attack is done";
                    memory.Set("IsAttackReady", false);
                    _decisionReceivedString = string.Empty;
                    _secondsSinceAttackStarted = 0;
                    _currentCooldown = 0;
                    _isBusy = false;
                }

                string lJoin = string.Join("\n",_decisionReceivedString, lIsAttackReadyText, lIsAttackProcessingText);

                _combatComponentPanel = new(lJoin)
                {
                    Header = new PanelHeader(" Combat Component Update "),
                    Border = BoxBorder.Double,
                    BorderStyle = new Style(foreground: Color.Orange1),
                    Width = 40
                };
            }
            AnsiConsole.Write(_combatComponentPanel);
        }
    }
}
