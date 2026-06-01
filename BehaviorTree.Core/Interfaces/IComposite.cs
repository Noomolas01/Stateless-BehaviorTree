namespace BehaviorTree.Core.Interfaces;

public interface IComposite
{
    List<ANode> Children { get; }
    public Result ProcessChildren();
    public void Add(ANode pNode);
}
