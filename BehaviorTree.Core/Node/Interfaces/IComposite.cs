
using BehaviorTree.Core.Node.Abstract;

namespace BehaviorTree.Core.Node.Interfaces;

public interface IComposite
{
    List<ANode> Children { get; }
    public TickResult ProcessChildren();
    public void Add(ANode pNode);
}
