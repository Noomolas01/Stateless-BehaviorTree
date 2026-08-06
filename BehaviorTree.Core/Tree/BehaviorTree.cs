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
        private readonly Selector _root = new Selector();
        private BehaviorTree() { }

        public override TickResult Tick(BB pWorldContext, BB pMemory)
        {
            return _root.Tick(pWorldContext, pMemory);
        }

  
        public class Builder
        {
            private readonly BehaviorTree _tree = new BehaviorTree();
            private readonly Stack<IComposite> _composites = new Stack<IComposite>();

            public BehaviorTree.Builder Selector()
            {
                IComposite lParent = GetParent();
                Selector lNewSelector = new Selector();
                lParent.Add(lNewSelector);
                _composites.Push(lNewSelector);

                return this;
            }

            public BehaviorTree.Builder Sequence()
            {
                IComposite lParent = GetParent();
                Sequence lNewSequence = new Sequence();
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
                lParent.Add(pBehaviorTree);

                return this;
            }

            private IComposite GetParent()
            {
                if (_composites.Count == 0)
                    return _tree._root;

                IComposite lParent = _composites.Peek();

                return lParent ??= _tree._root;
            }

            public BehaviorTree Build()
            {
                return _tree;
            }

        }
    }
}
