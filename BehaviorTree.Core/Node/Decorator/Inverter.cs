using BehaviorTree.Core;
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree.DataManagement;
public class Inverter : ADecorator
{
    protected override TickResult Decorate(ANode pNode, Blackboard pWorldContext, Blackboard pMemory)
    {
        TickResult lChildTickResult = child!.Tick(pWorldContext, pMemory);

        switch (lChildTickResult.status)
        {
            case NodeStatus.SUCCESS:
                return new TickResult(NodeStatus.FAILURE, lChildTickResult.decision, pMemory);
            case NodeStatus.RUNNING:
                return lChildTickResult;
            case NodeStatus.FAILURE:
                return new TickResult(NodeStatus.SUCCESS, lChildTickResult.decision, pMemory);
            default:
                throw new System.Exception("Decorator didn't return a valid node' status");
        }
    }
}