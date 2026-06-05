using System.Diagnostics;
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Interfaces;
using BehaviorTree.Core.Tree;

namespace BehaviorTree.Core.Node.Composite;

public class Selector : ANode, IComposite
{
    public List<ANode> Children { get; } = [];
    private int _LastChildrenIndex = 0;

    public TickResult ProcessChildren(WorldContext pWorldState, Blackboard pBlackboard)
    {
        for (int i = _LastChildrenIndex; i < Children.Count; i++)
        {
            TickResult lCurrentChildResult = Children[i].Tick(pWorldState, pBlackboard);

            if (lCurrentChildResult.status == NodeStatus.SUCCESS)
            {
                _LastChildrenIndex = 0;
                return lCurrentChildResult;
            }

            else if (lCurrentChildResult.status == NodeStatus.RUNNING)
            {
                _LastChildrenIndex = i;
                return lCurrentChildResult;
            }
        }

        _LastChildrenIndex = 0;
        return new TickResult(NodeStatus.FAILURE, null);
    }

    public void Add(ANode pNode)
    {
        if (pNode == null)
        {
            Console.Write($"{name} cannot add a null node.");
            return;
        }

        if (pNode == this)
        {
            Console.Write($"{name} cannot add itself.");
            return;
        }

        Children.Add(pNode);
    }

    public override TickResult Tick(WorldContext pWorldState, Blackboard pBlackboard)
    {
        return ProcessChildren(pWorldState, pBlackboard);
    }
}
