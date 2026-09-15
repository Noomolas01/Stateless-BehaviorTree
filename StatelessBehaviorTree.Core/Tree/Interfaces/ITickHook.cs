using StatelessBehaviorTree.Core.Node.Abstract;
using StatelessBehaviorTree.Core.Tree.Results;

namespace StatelessBehaviorTree.Core.Tree.Interfaces
{
    public interface ITickHook
    {
        void OnTickStart(ANode pNode);
        void OnTickEnd(ANode pNode, TickResult pResult);
    }
}
