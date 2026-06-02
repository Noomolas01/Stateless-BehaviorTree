
using BehaviorTree.Core.Node.Abstract;

namespace BehaviorTree.Core.Node.Interfaces;

public interface IComposite
{
    List<ANode> Children { get; }
    public Result ProcessChildren();
    public void Add(ANode pNode);
}
