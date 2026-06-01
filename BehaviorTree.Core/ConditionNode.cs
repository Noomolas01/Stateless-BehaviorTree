namespace BehaviorTree.Core;

public class ConditionNode : Node
{
    public override void Tick()
    {
        Console.WriteLine("Do Condition");
    }
}
