using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using System.Collections.Generic;

namespace BehaviorTree.Core.Node.Composite.Interfaces
{
    public interface IComposite
    {
        public List<ANode> Children { get; }
        public TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory);
        public void Add(ANode pNode);
    }

}