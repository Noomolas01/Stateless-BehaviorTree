// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Composite.Abstract;
using BehaviorTree.Core.Tree;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using System;

namespace BehaviorTree.Core.Node.Composite
{
    public class Sequence : AComposite
    {
        private ANode? _CurrentChild;
        private int _LastChildrenIndex = 0;


        public Sequence(string pName = "") : base(pName)
        {
        }

        public override TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickObserver = null)
        {
            for (int i = _LastChildrenIndex; i < Children.Count; i++)
            {
                _CurrentChild = Children[i];

                pTickObserver?.OnTickStart(_CurrentChild);
                TickResult lCurrentChildResult = _CurrentChild.Tick(pWorldContext, pMemory, pTickObserver);
                pTickObserver?.OnTickEnd(_CurrentChild, lCurrentChildResult);

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

        public void GetChildrenName()
        {
            foreach (var child in Children)
            {
                Console.WriteLine(child.name);

                if (child is Selector || child is Sequence)
                {
                    ((Sequence)child).GetChildrenName();
                }
            }
        }

        public override void Add(ANode pNode)
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