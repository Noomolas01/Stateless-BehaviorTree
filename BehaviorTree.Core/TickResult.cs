namespace BehaviorTree.Core;

public class TickResult(NodeStatus pResult, IAIDecision? pAIDecision)
{
    public IAIDecision? decision = pAIDecision;
    public NodeStatus status = pResult;
}
