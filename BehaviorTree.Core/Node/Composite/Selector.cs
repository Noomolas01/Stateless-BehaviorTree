using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Interfaces;
using BehaviorTree.Core.Tree;
using System.Collections.Generic;
using System;
using BehaviorTree.Core.Tree.DataManagement;

namespace BehaviorTree.Core.Node.Composite
{
    public class Selector : ANode, IComposite
    {
        public List<ANode> Children { get; } = new List<ANode>();
        private int _LastChildrenIndex = 0;

        public TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory)
        {
            for (int i = _LastChildrenIndex; i < Children.Count; i++)
            {
                TickResult lCurrentChildResult = Children[i].Tick(pWorldContext, pMemory);

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
