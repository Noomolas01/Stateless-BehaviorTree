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
        // World State 
        WorldContext context = new();

        context.Set<FakePlayer>("Player", new FakePlayer(new() { X = 0, Y = 0 }));
        blackboard.Set

        _Brain = new BT.Builder()
                    .Sequence()
                        .Action(new FindTarget())
                        .Selector()
                            .Sequence()
                                .Condition(new FakeTargetWithinMeleeRange())
                                .Condition(new FakeMeleeAttackCDIsFinished())
                                .Action(new FakeMeleeAttack())
                            .End()
                            .Sequence()
                                .Condition(new FakeTargetWithinDistanceRange())
                                .Condition(new FakeRangeAttackCDIsFinished())
                                .Action(new FakeRangeAttack())
                            .End()
                        .End()
                    .End()
                    .Action(new FakeIdle())
                    .Build();

    }

}
