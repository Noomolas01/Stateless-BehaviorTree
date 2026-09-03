using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree.Results;

namespace BehaviorTree.Core.Tree.Interfaces
{
    public interface ITickObserver
    {
        void OnTickStart(ANode pNode);
        void OnTickEnd(ANode pNode, TickResult pResult);
    }
}
