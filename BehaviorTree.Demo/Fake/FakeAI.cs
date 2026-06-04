using BehaviorTree.Core;
using BehaviorTree.Core.Node.Interfaces;
using BehaviorTree.Core.Node.Leaf;
using BehaviorTree.Core.Struct;
using BehaviorTree.Core.Tree;
using BT = BehaviorTree.Core.Tree.BehaviorTree;

namespace BehaviorTree.Demo.Fake;

public class FakeAI
{
    private readonly BT _Brain;

    public FakeAI()
    {
        // Memory
        Blackboard blackboard = new();
        //Sensors ?
        WorldContext context = new();

        _Brain = new BT.Builder()
                    .Sequence()
                        .Action(new FindTarget())
                        .Selector()
                            .Sequence()
                                .Condition(new TargetWithinMeleeRange())
                                .Condition(new MeleeAttackCDIsFinished())
                                .Action(new MeleeAttack())
                            .End()
                            .Sequence()
                                .Condition(new TargetWithinDistanceRange())
                                .Condition(new RangeAttackCDIsFinished())
                                .Action(new RangeAttack())
                            .End()
                        .End()
                    .End()
                    .Action(new Idle())
                    .Build();

        TickResult tickResult = _Brain.Tick(context, blackboard);

    
    }

}
