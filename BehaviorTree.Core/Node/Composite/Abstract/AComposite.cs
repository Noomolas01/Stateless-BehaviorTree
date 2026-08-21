using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Interfaces;
using BehaviorTree.Core.Tree.Results;
using System;
using System.Collections.Generic;

namespace BehaviorTree.Core.Node.Composite.Abstract
{
    public abstract class AComposite : ANode
    {
        protected  ANode? currentChild;
        protected int lastChildrenIndex = 0;
        public AComposite(string pName = "") : base(pName) { }
        public List<ANode> Children { get; } = new List<ANode>();
        public abstract TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickObserver = null);
        public void Add(ANode pNode)
        {
            if (pNode == null)
            {
                Console.WriteLine($"{name} cannot add a null node.");
                return;
            }

            if (pNode == this)
            {
                Console.WriteLine($"{name} cannot add itself.");
                return;
            }

            Children.Add(pNode);
        }
    } 
}
