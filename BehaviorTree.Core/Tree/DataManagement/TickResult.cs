using BehaviorTree.Core.Tree;
using BehaviorTree.Core.Tree.DataManagement;

namespace BehaviorTree.Core
{
    public readonly struct TickResult
    {
        public readonly IAIDecision? decision;
        public readonly NodeStatus status;
        public readonly Blackboard blackboard;

        public TickResult(NodeStatus pResult, IAIDecision? pAIDecision, Blackboard pBlackboard)
        {
            decision = pAIDecision;
            status = pResult;
            blackboard = pBlackboard;
        }

        public override string ToString()
        {
            return $"STATUS: {status} | DECISION: {(decision == null ? "null" : decision.GetType().Name)}";
        }
    }
}