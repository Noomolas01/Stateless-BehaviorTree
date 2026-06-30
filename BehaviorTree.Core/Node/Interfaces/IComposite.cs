
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;
using BehaviorTree.Core.Tree.DataManagement;
using System.Collections.Generic;

namespace BehaviorTree.Core.Node.Interfaces
{
    public interface IComposite
    {
        List<ANode> Children { get; }
        public TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory);
        public void Add(ANode pNode);
    }

}