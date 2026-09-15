using StatelessBehaviorTree.Core.Tree.Blackboard;
using StatelessBehaviorTree.Demo.Fake.Components;
using System.Text;

namespace StatelessBehaviorTree.Demo.Fake
{
    internal class Entity
    {
        public readonly AIComponent aiComponent;
        private readonly MovementComponent _movementComponent;
        public readonly CombatComponent combatComponent;
        public Blackboard Memory { get; private set; } = new();

        public readonly string id;

        public Entity(string pid)
        {
            id = pid;
            aiComponent = new AIComponent(this);
            _movementComponent = new MovementComponent(Memory);
            combatComponent = new CombatComponent(Memory);

            this.Memory.Set("id", id);

            aiComponent.decisionEmitter += _movementComponent.OnDecision;
            aiComponent.decisionEmitter += combatComponent.OnDecision;
        }

        public void SetMemory(Blackboard pMemory)
        {
            Memory = pMemory;
        }

        public void Update(float pDeltaTime)
        {
            _movementComponent.Update(pDeltaTime);
            combatComponent.Update(pDeltaTime);
            aiComponent.Update(pDeltaTime);
        }
    }
}
