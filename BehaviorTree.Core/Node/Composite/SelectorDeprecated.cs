// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Node.Abstract;
using System.Collections.Generic;
using System;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using BehaviorTree.Core.Node.Composite.Interfaces;
using BehaviorTree.Core.Tree;

namespace BehaviorTree.Core.Node.Composite
{
    [Obsolete]
    internal class SelectorDeprecated : ANode, IComposite
    {
        public List<ANode> Children { get; } = new List<ANode>();
        private ANode? _CurrentChild;
        private int _LastChildrenIndex = 0;

        public SelectorDeprecated(string pName = "") : base(pName)
        {
        }

        public TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickObserver = null)
        {
            for (int i = _LastChildrenIndex; i < Children.Count; i++)
            {
                _CurrentChild = Children[i];

                TickResult lCurrentChildResult = _CurrentChild.Tick(pWorldContext, pMemory, pTickObserver);
                pTickObserver?.OnTick(_CurrentChild, lCurrentChildResult);

                if (lCurrentChildResult.status == NodeStatus.SUCCESS)
                {
                    _LastChildrenIndex = 0;
                    return lCurrentChildResult;
                }

                else if (lCurrentChildResult.status == NodeStatus.RUNNING)
                {
                    _LastChildrenIndex = i;
                    return lCurrentChildResult;
                }
            }

            _LastChildrenIndex = 0;
            return new TickResult(NodeStatus.FAILURE, null, pMemory);
        }

        public void GetChildrenName()
        {
            foreach (var child in Children)
            {
                Console.WriteLine(child.name);

                if (child is SelectorDeprecated || child is SequenceDeprecated)
                {
                    ((SequenceDeprecated)child).GetChildrenName();
                }
            }
        }

        public void Add(ANode pNode)
        {
            if (pNode == null)
            {
                Console.Write($"{name} cannot add a null node.");
                return;
            }

            if (pNode == this)
            {
                Console.Write($"{name} cannot add itself.");
                return;
            }

            Children.Add(pNode);
        }

        public override TickResult Tick(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickOberver = null)
        {
            return ProcessChildren(pWorldContext, pMemory, pTickOberver);
        }
    }
}
