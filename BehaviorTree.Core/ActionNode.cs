namespace BehaviorTree.Core
{
    public class ActionNode : Node
    {
        public override void Tick()
        {
            Console.WriteLine("Do Action Node");
        }
    }
}