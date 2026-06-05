
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;

namespace BehaviorTree.Core.Node.Interfaces;

public interface IComposite
{
    List<ANode> Children { get; }
    public TickResult ProcessChildren(WorldContext pWorldState, Blackboard pBlackboard);
    public void Add(ANode pNode);
}
