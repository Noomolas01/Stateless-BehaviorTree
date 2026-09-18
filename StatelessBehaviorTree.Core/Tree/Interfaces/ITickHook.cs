using StatelessBehaviorTree.Core.Node.Abstract;
using StatelessBehaviorTree.Core.Tree.Results;

namespace StatelessBehaviorTree.Core.Tree.Interfaces
{
    public interface ITickHook
    {
        void OnTickStart(ARuntimeNode pNode);
        void OnTickEnd(ARuntimeNode pNode, TickResult pResult);
    }
}
