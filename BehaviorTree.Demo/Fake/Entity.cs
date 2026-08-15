

using BehaviorTree.Core.Tree;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using BehaviorTree.Demo.Fake.Decisions;
using System.Text;

namespace BehaviorTree.Demo.Fake
{
    internal class Entity
    {
        private readonly AIComponent _aiComponent;
        private readonly MovementComponent _movementComponent;
        private readonly CombatComponent _combatComponent;
        private readonly Blackboard _memory = new();

        public readonly string id;
        public readonly Core.Tree.BehaviorTree tree;

        public Entity(string pid, Core.Tree.BehaviorTree pTree)
        {
            id = pid;
            tree = pTree;
            _memory.Set("DebugOutput", new StringBuilder());
            _aiComponent = new AIComponent(this,tree, 1 / 60f, _memory);
            _movementComponent = new MovementComponent(_memory);
            _combatComponent = new CombatComponent(_memory);

            _aiComponent.sendDecision += _movementComponent.OnDecision;
            _aiComponent.sendDecision += _combatComponent.OnDecision;
        }

        public void SetMemory(Blackboard pMemory)
        {
            Memory = pMemory;
        }

        public void Update(float pDeltaTime)
        {
            _ElapsedTime += pDeltaTime;

            if (_ElapsedTime > _timeBetweenTick)
            {
                IAIDecision? lDecision = _tree.Tick(null!, memory).decision;
                Console.WriteLine($"{_owner.id}'s tree ticked");

                if (lDecision != null)
                    sendDecision?.Invoke(lDecision);

                _ElapsedTime = 0f;
            }
        }
    }
}
