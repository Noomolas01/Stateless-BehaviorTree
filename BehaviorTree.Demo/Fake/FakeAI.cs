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
    // Memory
    private readonly Blackboard blackboard = new();
    // World State 
    private readonly WorldContext context = new();


    public FakeAI()
    {
        context.Set<FakePlayer>("Player", new FakePlayer(new() { X = 0, Y = 0 }));
        blackboard.Set("MeleeCD", 3f);
        blackboard.Set("RangeCD", 3f);
        blackboard.Set("MeleeAttackFinished", false);
        blackboard.Set("RangeAttackFinished", false);
        blackboard.Set("Target", context.Get("Player"));

        _Brain = new BT.Builder()
                    .Sequence()
                        .Action(new TargetPlayer())
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

    public IAIDecision? GetDecision()
    {
        float? lMeleeCD = (float?)blackboard.Get("MeleeCD");
        float? lRangeCD = (float?)blackboard.Get("RangeCD");
        Console.WriteLine("before: " + lMeleeCD);
        Console.WriteLine("before: " + lRangeCD);

        blackboard.Set("MeleeCD", --lMeleeCD);
        blackboard.Set("RangeCD", --lRangeCD);
        Console.WriteLine("after: " + lMeleeCD);
        Console.WriteLine("after: " + lRangeCD);

        return _Brain.Tick(context, blackboard).decision;
    }

}
