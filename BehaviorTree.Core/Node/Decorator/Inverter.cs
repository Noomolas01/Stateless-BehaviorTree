using BehaviorTree.Core;
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree.DataManagement;
public class Inverter : ADecorator
{
    protected override TickResult Decorate(ANode pNode, WorldContext pWorldContext, Blackboard pBlackboard)
    {
        TickResult lChildTickResult = child!.Tick(pWorldContext, pBlackboard);

        switch (lChildTickResult.status)
        {
            case NodeStatus.SUCCESS:
                return new TickResult(NodeStatus.FAILURE, lChildTickResult.decision, pBlackboard);
            case NodeStatus.RUNNING:
                return lChildTickResult;
            case NodeStatus.FAILURE:
                return new TickResult(NodeStatus.SUCCESS, lChildTickResult.decision, pBlackboard);
            default:
                throw new System.Exception("Decorator didn't return a valid node' status");
        }
    }
}