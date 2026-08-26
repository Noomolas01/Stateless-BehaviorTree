using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Interfaces;
using BehaviorTree.Core.Tree.Results;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BehaviorTree.Core.Node.Composite.Abstract
{
    public abstract class AComposite : ANode
    {
        protected readonly ConditionalWeakTable<Blackboard, CompositeData> dataByBlackboard = new ConditionalWeakTable<Blackboard, CompositeData>();
        public List<ANode> Children { get; private set; } = new List<ANode>();

        public AComposite(string pName = "") : base(pName) { }

        public abstract TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickObserver = null);
        public void Add(ANode pNode)
        {
            if (pNode == null)
            {
                throw new ArgumentException($"{name} cannot add a null node.");
            }

            if (pNode == this)
            {
                throw new ArgumentException($"{name} cannot add a null node.");
            }


            Children.Add(pNode);
        }
    }
}
