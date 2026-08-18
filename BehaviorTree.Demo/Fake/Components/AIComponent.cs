using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;

namespace BehaviorTree.Demo.Fake.Components
{
    internal class AIComponent
    {
        private float _ElapsedTime = 0f;
        private float _timeBetweenTick;
        private Core.Tree.BehaviorTree? _tree;

        public Blackboard? memory;
        public Action<IAIDecision>? sendDecision;

        private readonly Entity _owner;


        public AIComponent(Entity pOwner)
        {
            _owner = pOwner;
        }

        public void Init(Core.Tree.BehaviorTree? pTree, float pTickDuration, Blackboard? pMemory)
        {
            ArgumentNullException.ThrowIfNull(pTree);
            ArgumentNullException.ThrowIfNull(pMemory);

            _tree = pTree;
            _timeBetweenTick = pTickDuration;
            memory = pMemory;
        }
        public void Update(float pDeltaTime)
        {
            ArgumentNullException.ThrowIfNull(_tree);
            ArgumentNullException.ThrowIfNull(memory);

            if (_ElapsedTime == 0)
            {
                IAIDecision? lDecision = _tree.Tick(null!, memory).decision;
                Console.WriteLine($"{_owner.id}'s tree ticked");

                if (lDecision != null)
                    sendDecision?.Invoke(lDecision);

            }

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
