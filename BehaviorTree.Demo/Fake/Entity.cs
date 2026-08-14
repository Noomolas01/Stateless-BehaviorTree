

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

        public void Update(float pDeltaTime)
        {
            _aiComponent.Update(pDeltaTime);
            _movementComponent.Update(pDeltaTime);
            _combatComponent.Update(pDeltaTime);
        }
    }
    internal abstract class AComponent
    {
        protected readonly Blackboard _memory;
        protected bool _isBusy;

        public AComponent(Blackboard pMemory)
        {
            _memory = pMemory;
        }
        public abstract void Update(float pDeltaTime);
        public abstract void OnDecision(IAIDecision pDecision);

    }

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

            // When component has finished its job, it writes in the memory how it went
        }
    }


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

    internal class AIComponent
    {
        private float _ElapsedTime = 0f;
        private readonly float _timeBetweenTick;
        private readonly Core.Tree.BehaviorTree _tree;

        public Blackboard memory;
        public Action<IAIDecision>? sendDecision;

        private readonly Entity _owner;
        

        public AIComponent(Entity pOwner, Core.Tree.BehaviorTree pTree, float pTickDuration, Blackboard pBlackboard)
        {
            _tree = pTree;
            _timeBetweenTick = pTickDuration;
            memory = pBlackboard;
            _owner = pOwner;
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
