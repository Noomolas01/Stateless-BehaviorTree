namespace BehaviorTree.Core
{
    public struct TickResult
    {
        public IAIDecision? decision;
        public NodeStatus status;
        public TickResult(NodeStatus pResult, IAIDecision? pAIDecision)
        {
            decision = pAIDecision;
            status = pResult;
        }

        public override string ToString()
        {
            return $"STATUS: {status} | DECISION: {(decision == null ? "null" : decision.GetType().Name)}";
        }
    }
}