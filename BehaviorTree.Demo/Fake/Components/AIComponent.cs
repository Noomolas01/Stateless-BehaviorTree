using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using Spectre.Console;

namespace BehaviorTree.Demo.Fake.Components
{
    internal class AIComponent
    {
        private float _ElapsedTime = 0f;
        private float _timeBetweenTick;
        private Core.Tree.BehaviorTree? _tree;

        public Blackboard? memory;
        public Action<IAIDecision>? decisionEmitter;

        private readonly Entity _owner;

        private bool _tickedAtStart;
        private int _tickCount = 0;

        public AIComponent(Entity pOwner)
        {
            _owner = pOwner;
        }

        public void Init(Core.Tree.BehaviorTree? pTree, float pTimeBetweenTickInSec, Blackboard? pMemory)
        {
            ArgumentNullException.ThrowIfNull(pTree);
            ArgumentNullException.ThrowIfNull(pMemory);

            _tree = pTree;
            _timeBetweenTick = pTimeBetweenTickInSec;
            memory = pMemory;
        }
        public void Update(float pDeltaTime)
        {
            ArgumentNullException.ThrowIfNull(_tree);
            ArgumentNullException.ThrowIfNull(memory);

            if (_ElapsedTime == 0 && !_tickedAtStart)
            {
                IAIDecision? lDecision = _tree.Tick(null!, memory).decision;

                _tickCount++;
                if (lDecision != null)
                    decisionEmitter?.Invoke(lDecision);
                _tickedAtStart = true;

                AnsiConsole.Write(new Markup($"[IndianRed_1]Tick n°{_tickCount}[/]\n"));

                return;

            }

            _ElapsedTime += pDeltaTime;

            if (_ElapsedTime >= _timeBetweenTick)
            {
                IAIDecision? lDecision = _tree.Tick(null!, memory).decision;
                _tickCount++;

                if (lDecision != null)
                    decisionEmitter?.Invoke(lDecision);

                _ElapsedTime = 0f;
            }

            AnsiConsole.Write(new Markup($"[IndianRed_1]Tick n°{_tickCount}[/]\n"));

        }
    }
}
