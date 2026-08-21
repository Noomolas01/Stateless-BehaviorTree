using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using BehaviorTree.Demo.Fake.Decisions;
using Spectre.Console;
using System;

namespace BehaviorTree.Demo.Fake.Components
{
    internal class CombatComponent : AComponent
    {
        private int _frameCount;
        private int _attackDurationInFrame = 5;
        private int _attackCooldownInFrame = 10;

        private int _currentCooldown;

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
            if (_currentCooldown < _attackCooldownInFrame)
            {
                lIsAttackReadyText = "Attack is not ready yet";
                _currentCooldown++;

            }

            else
            {

                memory.Set("IsAttackReady", true);

                // Here handle combat logic...
                _frameCount++;
                string lIsAttackProcessingText = "Attack is processing...";

                // When component has finished its job, it writes in the Memory how it went
                if (_frameCount >= _attackDurationInFrame)
                {
                    memory.Set("AttackFinished", true);
                    lIsAttackProcessingText = "Attack is done";
                    memory.Set("IsAttackReady", false);
                    _decisionReceivedString = string.Empty;
                    _frameCount = 0;
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
