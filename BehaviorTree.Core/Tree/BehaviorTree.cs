using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Composite;
using BehaviorTree.Core.Node.Interfaces;
using BehaviorTree.Core.Tree.DataManagement;
using System.Collections.Generic;

namespace BehaviorTree.Core.Tree
{
    public sealed class BehaviorTree : ANode
    {
        private readonly Selector _root = new Selector();
        private BehaviorTree() { }

        public override TickResult Tick(Blackboard pWorldContext, Blackboard pMemory)
        {
            return _root.Tick(pWorldContext, pMemory);
        }

        public class Builder
        {
            private readonly BehaviorTree _brain = new BehaviorTree();
            private readonly Stack<IComposite> _nodes = new Stack<IComposite>();


            public BehaviorTree.Builder Selector()
            {
                IComposite lParent = GetParent();
                Selector lNewSelector = new Selector();
                lParent.Add(lNewSelector);
                _nodes.Push(lNewSelector);

                return this;
            }

            public BehaviorTree.Builder Sequence()
            {
                IComposite lParent = GetParent();
                Sequence lNewSequence = new Sequence();
                lParent.Add(lNewSequence);
                _nodes.Push(lNewSequence);

                return this;
            }

            public BehaviorTree.Builder End()
            {
                if (_nodes.Count > 0)
                    _nodes.Pop();

                return this;
            }

            public BehaviorTree.Builder Action(AActionNode pActionNode)
            {
                IComposite lParent = GetParent();
                lParent.Add(pActionNode);

                return this;
            }

            public BehaviorTree.Builder Action(AActionNode pActionNode, ADecorator pDecorator)
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

            public BehaviorTree.Builder Condition(AConditionNode pActionNode, ADecorator pDecorator)
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
                if (_nodes.Count == 0)
                    return _brain._root;

                IComposite lParent = _nodes.Peek();

                return lParent ??= _brain._root;
            }

            public BehaviorTree Build()
            {
                return _brain;
            }

        }
    }
}
