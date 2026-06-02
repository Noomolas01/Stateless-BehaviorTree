using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Interfaces;

namespace BehaviorTree.Core.Node.Composite;

public class Selector : ANode, IComposite
{
    public List<ANode> Children { get; } = [];
    private int _LastChildrenIndex = 0;

    public Result ProcessChildren()
    {
        for (int i = _LastChildrenIndex; i < Children.Count; i++)
        {
            Result lCurrentChildResult = Children[i].Tick();

            if (lCurrentChildResult == Result.SUCCESS)
            {
                _LastChildrenIndex = 0;
                return Result.SUCCESS;
            }

            else if (lCurrentChildResult == Result.RUNNING)
            {
                _LastChildrenIndex = i;
                return Result.RUNNING;
            }
        }

        _LastChildrenIndex = 0;
        return Result.FAILURE;
    }

    public void Add(ANode pNode) => Children.Add(pNode);
    public override Result Tick()
    {
        return ProcessChildren();
    }


}
