using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using System.Collections.Generic;

namespace BehaviorTree.Core.Node.Composite.Abstract
{
    public abstract class AComposite : ANode
    {

        public AComposite(string pName = "") : base(pName) { }
        public List<ANode> Children { get; } = new List<ANode>();
        public abstract TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickObserver = null);
        public abstract void Add(ANode pNode);

    }
}
