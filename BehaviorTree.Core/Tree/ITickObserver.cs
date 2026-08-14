using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree.Results;

namespace BehaviorTree.Core.Tree
{
    public interface ITickObserver
    {
        void OnTick(ANode pNode, TickResult pResult);
    }
}
