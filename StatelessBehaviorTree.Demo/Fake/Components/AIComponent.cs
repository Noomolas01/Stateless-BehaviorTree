using StatelessBehaviorTree.Core.Tree.Blackboard;
using StatelessBehaviorTree.Core.Tree.Results;
using Spectre.Console;
using StatelessBehaviorTree.Core.Tree;
using StatelessBehaviorTree.Core.Tree.Interfaces;

namespace StatelessBehaviorTree.Demo.Fake.Components
{
    internal class AIComponent
    {
        private float _ElapsedTime = 0f;
        private float _timeBetweenTick;

        public Blackboard? memory;
        private BehaviorTree? _tree;
        public Action<IAIDecision>? decisionEmitted;
        private ITickHook? _tickHook = null;

        private readonly Entity _owner;

        private bool _tickedAtStart;
        private int _tickCount = 0;

        public AIComponent(Entity pOwner)
        {
            _owner = pOwner;
        }

        public void Init(BehaviorTree? pTree, float pTimeBetweenTickInSec, Blackboard? pMemory, ITickHook? pTickHook = null)
        {
            ArgumentNullException.ThrowIfNull(pTree);
            ArgumentNullException.ThrowIfNull(pMemory);

            _tickHook = pTickHook;
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
                IAIDecision? lDecision = _tree.Tick(null!, memory, _tickHook).decision;

                _tickCount++;
                if (lDecision != null)
                    decisionEmitted?.Invoke(lDecision);
                _tickedAtStart = true;

                AnsiConsole.Write(new Markup($"[IndianRed_1]Tick n°{_tickCount}[/]\n"));

                return;

            }

            _ElapsedTime += pDeltaTime;

            if (_ElapsedTime >= _timeBetweenTick)
            {
                IAIDecision? lDecision = _tree.Tick(null!, memory, _tickHook).decision;
                _tickCount++;

                if (lDecision != null)
                    decisionEmitted?.Invoke(lDecision);

                _ElapsedTime = 0f;
            }

            AnsiConsole.Write(new Markup($"[IndianRed_1]Tick n°{_tickCount}[/]\n"));

        }
    }
}
