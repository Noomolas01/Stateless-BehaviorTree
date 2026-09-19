using StatelessBehaviorTree.Core.Node.Abstract;
using StatelessBehaviorTree.Core.Tree.Results;
using StatelessBehaviorTree.Core.Tree.Data;

namespace StatelessBehaviorTree.Core.Tree.Interfaces
{
    public interface ITickHook
    {
        void Init(ARuntimeNode pRoot);
        void OnTickStart(ARuntimeNode pNode, Data.Blackboard pMemory);
        void OnTickEnd(ARuntimeNode pNode, TickResult pResult);
    }
}
