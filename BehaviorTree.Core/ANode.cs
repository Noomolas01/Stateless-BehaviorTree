namespace BehaviorTree.Core
{
    public abstract class ANode
    {
        public string Name = "";
        public abstract Result Tick();
    }
}
