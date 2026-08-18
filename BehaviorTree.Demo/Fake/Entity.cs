using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Demo.Fake.Components;
using System.Text;

namespace BehaviorTree.Demo.Fake
{
    internal class Entity
    {
        public readonly AIComponent aiComponent;
        private readonly MovementComponent _movementComponent;
        private readonly CombatComponent _combatComponent;
        public Blackboard Memory { get; private set; } = new();

        public readonly string id;

        public Entity(string pid)
        {
            id = pid;
            Memory.Set("DebugOutput", new StringBuilder());
            aiComponent = new AIComponent(this);
            _movementComponent = new MovementComponent(Memory);
            _combatComponent = new CombatComponent(Memory);

            aiComponent.sendDecision += _movementComponent.OnDecision;
            aiComponent.sendDecision += _combatComponent.OnDecision;
        }

        public void SetMemory(Blackboard pMemory)
        {
            Memory = pMemory;
        }

        public void Update(float pDeltaTime)
        {
            _movementComponent.Update(pDeltaTime);
            _combatComponent.Update(pDeltaTime);
            aiComponent.Update(pDeltaTime);
        }
    }
}
