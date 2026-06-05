using BehaviorTree.Core;
using BehaviorTree.Core.Tree;

namespace BehaviorTree.Demo.Fake;

public class FakeAttackManager(Blackboard pBlackboard)
{
    private readonly Blackboard _blackboard = pBlackboard;
    private float _CurrentMeleeAtkCooldown;
    private readonly float _MaxMeleeCooldown = 3f;

    private float _CurrentRangeAtkCooldown;
    private readonly float _MaxRangeCooldown = 3f;

    private bool? IsRangeAttackFinished
    {
        get => (bool?)_blackboard.Get("RangeAttackFinished");
        set => _blackboard.Set("RangeAttackFinished", value);
    }
    private bool? IsMeleeAttackFinished
    {
        get => (bool?)_blackboard.Get("MeleeAttackFinished");
        set => _blackboard.Set("MeleeAttackFinished", value);
    }
    private bool _isMeleeAtackStarted = false;
    private bool _isRangeAtackStarted = false;

    private int _frameCounter = 0;

    public void ReactOn(AttackDecision pDecision)
    {
        switch (pDecision.attackType)
        {
            case AttackType.MELEE:

                if (_CurrentMeleeAtkCooldown >= _MaxMeleeCooldown && !_isMeleeAtackStarted)
                {
                    Console.WriteLine("Je dégaine mon épée...");
                    _CurrentMeleeAtkCooldown = 0;
                    _blackboard.Set("MeleeIsReady", false);
                    _blackboard.Set("MeleeCD", _CurrentMeleeAtkCooldown);

                    _isMeleeAtackStarted = true;
                }
                break;

            case AttackType.RANGE:

                if (_CurrentRangeAtkCooldown >= _MaxRangeCooldown && !_isRangeAtackStarted)
                {
                    Console.WriteLine("Je bande mon arc...");
                    _CurrentRangeAtkCooldown = 0;
                    _blackboard.Set("RangeIsReady", false);
                    _blackboard.Set("RangeCD", _CurrentRangeAtkCooldown);

                    _isRangeAtackStarted = true;
                }
                break;

            default:
                break;
        }
    }


    public void FakeUpdate()
    {
        _CurrentMeleeAtkCooldown++;
        _CurrentRangeAtkCooldown++;

        Console.WriteLine($"Melee CD : {_CurrentMeleeAtkCooldown}");
        Console.WriteLine($"Range CD : {_CurrentRangeAtkCooldown}");

        _blackboard.Set("RangeCD", _CurrentRangeAtkCooldown);
        _blackboard.Set("MeleeCD", _CurrentMeleeAtkCooldown);

        if (_CurrentMeleeAtkCooldown >= _MaxMeleeCooldown)
        {
            _blackboard.Set("MeleeIsReady", true);
        }

        if (_CurrentRangeAtkCooldown >= _MaxRangeCooldown)
        {
            _blackboard.Set("RangeIsReady", true);
        }

        // Attack Logic
        if (_isMeleeAtackStarted || _isRangeAtackStarted)
        {

            // Attacks take 3 frames
                Console.WriteLine("frame counter attack " + _frameCounter);
            if (_frameCounter++ > 3)
            {

                if (_isMeleeAtackStarted)
                {
                    IsMeleeAttackFinished = true;
                    Console.WriteLine("Swoosh(Sword sound)");

                }

                if (_isRangeAtackStarted)
                {
                    IsRangeAttackFinished = true;
                    Console.WriteLine("Fffffshhh(Arrow sound)");
                }

                _frameCounter = 0;
            }


        }

    }
}
