namespace BehaviorTree.Core
{
    public abstract class ANode(string pName = "")
    {
        public string Name = pName;
        public abstract Result Tick();
    }
}
