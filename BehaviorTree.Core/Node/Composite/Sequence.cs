using System.ComponentModel;
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Interfaces;

namespace BehaviorTree.Core.Node.Composite;

public class Sequence : ANode, IComposite
{
    public List<ANode> Children { get; } = [];
    private int _LastChildrenIndex = 0;

    public TickResult ProcessChildren()
    {
        for (int i = _LastChildrenIndex; i < Children.Count; i++)
        {
            TickResult lCurrentChildResult = Children[i].Tick();

            if (lCurrentChildResult.status == NodeStatus.FAILURE)
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
        return new TickResult(NodeStatus.SUCCESS, null);
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
    public override TickResult Tick()
    {
        return ProcessChildren();
    }
}
