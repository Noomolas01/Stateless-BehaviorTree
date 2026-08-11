// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Composite;
using BehaviorTree.Core.Node.Composite.Interfaces;
using BehaviorTree.Core.Node.Decorator.Abstract;
using BehaviorTree.Core.Node.Leaf.Abstract;
using BehaviorTree.Core.Tree.Results;
using System;
using System.Collections.Generic;
using BB = BehaviorTree.Core.Tree.Blackboard.Blackboard;

namespace BehaviorTree.Core.Tree
{
    public sealed class BehaviorTree : ANode
    {
        public readonly Selector root = new Selector("Root");
        private BehaviorTree() 
        {

        }
        public override TickResult Tick(BB pWorldContext, BB pMemory, ITickObserver? pTickOberver = null)
        {
            return root.Tick(pWorldContext, pMemory, pTickOberver);
        }

        public void GetChildrenName()
        {
          root.GetChildrenName();
        }

        public class Builder
        {
            private readonly BehaviorTree _tree = new BehaviorTree();
            private readonly Stack<IComposite> _composites = new Stack<IComposite>();

            public BehaviorTree.Builder Selector(string pName = "")
            {
                IComposite lParent = GetParent();
                Selector lNewSelector = new Selector(pName);
                lParent.Add(lNewSelector);
                _composites.Push(lNewSelector);

                return this;
            }

            public BehaviorTree.Builder Sequence(string pName = "")
            {
                IComposite lParent = GetParent();
                Sequence lNewSequence = new Sequence(pName);
                lParent.Add(lNewSequence);
                _composites.Push(lNewSequence);

                return this;
            }

            public BehaviorTree.Builder End()
            {
                if (_composites.Count > 0)
                    _composites.Pop();

                return this;
            }

            public BehaviorTree.Builder Action(AActionNode pActionNode)
            {
                IComposite lParent = GetParent();
                lParent.Add(pActionNode);

                return this;
            }

            internal BehaviorTree.Builder Action(AActionNode pActionNode, ADecorator pDecorator)
            {
                IComposite lParent = GetParent();
                pDecorator.Init(pActionNode);
                lParent.Add(pDecorator);

                return this;
            }

            public BehaviorTree.Builder Condition(AConditionNode pConditionNode)
            {
                IComposite lParent = GetParent();
                lParent.Add(pConditionNode);

                return this;
            }

            internal BehaviorTree.Builder Condition(AConditionNode pActionNode, ADecorator pDecorator)
            {
                IComposite lParent = GetParent();
                pDecorator.Init(pActionNode);
                lParent.Add(pDecorator);

                return this;
            }

            public BehaviorTree.Builder Append(BehaviorTree pBehaviorTree)
            {
                IComposite lParent = GetParent();

                if (pBehaviorTree == _tree)
                {
                    Console.WriteLine("Error: Tree cannot add itself as a child");
                    return this;
                }

                foreach (var lChild in pBehaviorTree.root.Children)
                {
                    lParent.Add(lChild);
                }

                return this;
            }

            private IComposite GetParent()
            {
                if (_composites.Count == 0)
                    return _tree.root;

                IComposite lParent = _composites.Peek();

                return lParent ??= _tree.root;
            }

            public BehaviorTree Build()
            {
                return _tree;
            }

        }
    }
}
