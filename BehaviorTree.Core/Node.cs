
namespace BehaviorTree.Core
{
    public abstract class Node
    {
        public string Name = "";
        public abstract void Tick();
    }
}
