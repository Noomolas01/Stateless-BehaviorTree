using BehaviorTree.Core;
using BehaviorTree.Core.Node.Interfaces;
using BehaviorTree.Core.Node.Leaf;
using BehaviorTree.Core.Struct;
using BehaviorTree.Core.Tree;
using BT = BehaviorTree.Core.Tree.BehaviorTree;

namespace BehaviorTree.Demo.Fake;

public class FakeAI // : Node/Monobehaviour
{
    private readonly BT _Brain;
    // Memory
    private readonly Blackboard _blackboard = new();
    // World State 
    private readonly WorldContext context = new();
    //Components
    private readonly FakeAttackManager _fakeAttackManager;

    private int _tickCounter = 0;

    public FakeAI()
    {
        context.Set<FakePlayer>("Player", new FakePlayer(new() { X = 0, Y = 0 }));
        _blackboard.Set("MeleeCD", 3f);
        _blackboard.Set("RangeCD", 3f);
        _blackboard.Set("MeleeAttackFinished", false);
        _blackboard.Set("RangeAttackFinished", false);
        _blackboard.Set("MeleeIsReady", false);
        _blackboard.Set("RangeIsReady", false);
        _blackboard.Set("Target", context.Get("Player"));

        _fakeAttackManager = new FakeAttackManager(_blackboard);

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

    private void Think()
    {
        IAIDecision? lAIDecision = GetDecision();

        switch (lAIDecision)
        {
            case AttackDecision attackDecision:
                _fakeAttackManager.ReactOn(attackDecision);
                break;
            case null:
                break;
        }
    }

    public void FakeUpdate(int pFrameCounter)
    {
        _fakeAttackManager.FakeUpdate();
        

        if (pFrameCounter % 3 == 0)
        {
            _tickCounter++;
            Console.WriteLine($"Tick n°{_tickCounter} start");
            Think();
            Console.WriteLine($"Tick n°{_tickCounter} end");
        }

    }

    private IAIDecision? GetDecision()
    {
        float? lMeleeCD = (float?)_blackboard.Get("MeleeCD");
        float? lRangeCD = (float?)_blackboard.Get("RangeCD");

        IAIDecision? lDecision = _Brain.Tick(context, _blackboard).decision;
        
        Console.WriteLine($"Decision : {lDecision}");
        return lDecision;
    }

}
