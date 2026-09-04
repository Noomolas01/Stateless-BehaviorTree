using StatelessBehaviorTree.Core.Node.Abstract;
using StatelessBehaviorTree.Core.Tree.Blackboard;
using StatelessBehaviorTree.Core.Tree.Interfaces;
using StatelessBehaviorTree.Core.Tree.Results;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StatelessBehaviorTree.Core.Node.Composite.Abstract
{
    /// <summary>
    /// Base class for nodes that process multiple children node
    /// </summary>
    public abstract class AComposite : ANode
    {
        protected readonly ConditionalWeakTable<Blackboard, CompositeData> dataByBlackboard = new ConditionalWeakTable<Blackboard, CompositeData>();
        public List<ANode> Children { get; private set; } = new List<ANode>();
        public AComposite(string pName = "") : base(pName) { }

        public abstract TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory, ITickHook? pTickObserver = null);
        public void Add(ANode pNode)
        {
            if (pNode == null)
            {
                throw new ArgumentException($"{name} cannot add a null node.");
            }

            if (pNode == this)
            {
                throw new ArgumentException($"{name} cannot add itself as a node.");
            }


            Children.Add(pNode);
        }
    }
}
