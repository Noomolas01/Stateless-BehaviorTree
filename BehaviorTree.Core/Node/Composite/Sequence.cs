using System.ComponentModel;
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Interfaces;

namespace BehaviorTree.Core.Node.Composite;

public class Sequence : ANode, IComposite
{
    public List<ANode> Children { get; } = [];
    private int _LastChildrenIndex = 0;

    public Result ProcessChildren()
    {
        for (int i = _LastChildrenIndex; i < Children.Count; i++)
        {
            Result lCurrentChildResult = Children[i].Tick();

            if (lCurrentChildResult == Result.FAILURE)
            {
                _LastChildrenIndex = 0;
                return Result.FAILURE;
            }

            else if (lCurrentChildResult == Result.RUNNING)
            {
                _LastChildrenIndex = i;
                return Result.RUNNING;
            }
        }

        _LastChildrenIndex = 0;
        return Result.SUCCESS;
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
    public override Result Tick()
    {
        return ProcessChildren();
    }
}
