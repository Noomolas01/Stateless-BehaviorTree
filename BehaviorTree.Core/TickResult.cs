namespace BehaviorTree.Core
{
    public readonly struct TickResult
    {
        public readonly IAIDecision? decision;
        public readonly NodeStatus status;

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