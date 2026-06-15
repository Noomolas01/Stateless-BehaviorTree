using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Interfaces;
using BehaviorTree.Core.Tree;
using System.Collections.Generic;
using System;
using BehaviorTree.Core.Tree.DataManagement;

namespace BehaviorTree.Core.Node.Composite
{
    public class Sequence : ANode, IComposite
    {
        public List<ANode> Children { get; } = new List<ANode>();
        private int _LastChildrenIndex = 0;

        public TickResult ProcessChildren(WorldContext pWorldContext, Blackboard pBlackboard)
        {
            for (int i = _LastChildrenIndex; i < Children.Count; i++)
            {
                TickResult lCurrentChildResult = Children[i].Tick(pWorldContext, pBlackboard);

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
            return new TickResult(NodeStatus.SUCCESS, null, pBlackboard);
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
        public override TickResult Tick(WorldContext pWorldContext, Blackboard pBlackboard)
        {
            return ProcessChildren(pWorldContext, pBlackboard);
        }
    }

}