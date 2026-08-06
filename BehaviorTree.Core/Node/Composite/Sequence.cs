using BehaviorTree.Core.Node.Abstract;
using System.Collections.Generic;
using System;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using BehaviorTree.Core.Node.Composite.Interfaces;

namespace BehaviorTree.Core.Node.Composite
{
    public class Sequence : ANode, IComposite
    {
        public List<ANode> Children { get; } = new List<ANode>();
        private ANode? _CurrentChild;
        private int _LastChildrenIndex = 0;

        public TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory)
        {
            for (int i = _LastChildrenIndex; i < Children.Count; i++)
            {
                _CurrentChild = Children[i];
                TickResult lCurrentChildResult = _CurrentChild.Tick(pWorldContext, pMemory);

                if (lCurrentChildResult.status == NodeStatus.FAILURE)
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
            return new TickResult(NodeStatus.SUCCESS, null, pMemory);
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
        public override TickResult Tick(Blackboard pWorldContext, Blackboard pMemory)
        {
            return ProcessChildren(pWorldContext, pMemory);
        }
    }

}