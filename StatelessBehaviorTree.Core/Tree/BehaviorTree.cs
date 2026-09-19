// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using StatelessBehaviorTree.Core.Node.Abstract;
using StatelessBehaviorTree.Core.Node.Composite;
using StatelessBehaviorTree.Core.Node.Composite.Abstract;
using StatelessBehaviorTree.Core.Node.Decorator.Abstract;
using StatelessBehaviorTree.Core.Node.Leaf.Abstract;
using StatelessBehaviorTree.Core.Tree.Interfaces;
using StatelessBehaviorTree.Core.Tree.Results;
using System;
using System.Collections.Generic;
using BB = StatelessBehaviorTree.Core.Tree.Data.Blackboard;

namespace StatelessBehaviorTree.Core.Tree
{
    public class BehaviorTree
    {
        public AComposite? Root { get; private set; }
        private ITickHook? _tickHook = null;


        protected BehaviorTree() 
        {
        }

        public TickResult Tick(BB pWorldContext, BB pMemory)
        {
            TickResult lResult = Root!.Tick(pWorldContext, pMemory, _tickHook);
            return lResult;
        }

        public void Traverse(Action<ARuntimeNode>? pCallback)
        {
            if (Root == null)
                return;

            Traverse(Root, pCallback);
        }

        private void Traverse(AComposite pCompositeNode, Action<ARuntimeNode>? pCallback)
        {
            pCallback?.Invoke(pCompositeNode);

            foreach (var lChild in pCompositeNode.Children)
            {
                pCallback?.Invoke(lChild);

                if (lChild is AComposite lComposite)
                {
                    Traverse(lComposite, pCallback);
                }
            }
        }

        public class Builder
        {
            private readonly BehaviorTree _tree = new BehaviorTree();
            private readonly Stack<AComposite> _composites = new Stack<AComposite>();

            public BehaviorTree.Builder Selector(string pName = "")
            {
                Selector lNewSelector;

                if (_tree.Root == null)
                {
                    lNewSelector = new Selector(pName, true);
                    _tree.Root = lNewSelector;
                    return this;
                }

                lNewSelector = new Selector(pName);
                AComposite lParent = GetParent();
                lParent.Add(lNewSelector);
                _composites.Push(lNewSelector);

                return this;
            }

            public BehaviorTree.Builder Sequence(string pName = "")
            {
                Sequence lNewSequence;
                
                if (_tree.Root == null)
                {
                    lNewSequence = new Sequence(pName, true);
                    _tree.Root = lNewSequence;
                    return this;
                }

                lNewSequence = new Sequence(pName);

                AComposite lParent = GetParent();
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
                AComposite lParent = GetParent();
                lParent.Add(pActionNode);

                return this;
            }

            internal BehaviorTree.Builder Action(AActionNode pActionNode, ADecorator pDecorator)
            {
                AComposite lParent = GetParent();
                pDecorator.Init(pActionNode);
                lParent.Add(pDecorator);

                return this;
            }

            public BehaviorTree.Builder Condition(AConditionNode pConditionNode)
            {
                AComposite lParent = GetParent();
                lParent.Add(pConditionNode);

                return this;
            }

            internal BehaviorTree.Builder Condition(AConditionNode pActionNode, ADecorator pDecorator)
            {
                AComposite lParent = GetParent();
                pDecorator.Init(pActionNode);
                lParent.Add(pDecorator);

                return this;
            }

            public BehaviorTree.Builder Append(BehaviorTree pBehaviorTree)
            {
                AComposite lParent = GetParent();

                if (pBehaviorTree == _tree)
                {
                    Console.WriteLine("Error: Tree cannot add itself as a child");
                    return this;
                }

                lParent.Add(pBehaviorTree.Root!);

                return this;
            }

            private AComposite GetParent()
            {
                if (_tree.Root == null)
                    throw new Exception($"There's no root in this builder's tree");

                if (_composites.Count == 0)
                    return _tree.Root!;

                AComposite lParent = _composites.Peek();

                return lParent ??= _tree.Root!;
            }

            public BehaviorTree Build(ITickHook? pTickHook = null)
            {
                _tree._tickHook = pTickHook;
                _tree._tickHook?.Init(_tree.Root!);
                return _tree;
            }

        }
    }
}
