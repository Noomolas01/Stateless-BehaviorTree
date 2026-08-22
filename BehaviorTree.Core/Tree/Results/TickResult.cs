// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BB = BehaviorTree.Core.Tree.Blackboard.Blackboard;
namespace BehaviorTree.Core.Tree.Results
{
    public readonly struct TickResult
    {
        public readonly IAIDecision? decision;
        public readonly NodeStatus status;
        public readonly BB blackboard;

        public TickResult(NodeStatus pResult, IAIDecision? pAIDecision, BB pMemory)
        {
            decision = pAIDecision;
            status = pResult;
            blackboard = pMemory;
        }

        public override string ToString()
        {
            return $"STATUS: {status} | DECISION: {(decision == null ? "null" : decision.GetType().Name)}";
        }
    }
}