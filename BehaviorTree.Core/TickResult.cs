namespace BehaviorTree.Core;

public class TickResult(NodeStatus pResult, IAIDecision? pAIDecision)
{
    public IAIDecision? decision = pAIDecision;
    public NodeStatus status = pResult;

    public override string ToString()
    {
        return $"STATUS: {status} | DECISION: {(decision == null ? "null" : decision.GetType().Name)}";
    }
}
