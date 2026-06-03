using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Composite;
using BehaviorTree.Core.Node.Interfaces;

namespace BehaviorTree.Core.Tree
{
    public sealed class BehaviorTree : ANode
    {
        private readonly Selector root = new();
        private BehaviorTree() { }

        public override Result Tick()
        {
            return root.Tick();
        }

        public class Builder
        {
            private readonly BehaviorTree _brain = new();
            private readonly Stack<IComposite> _nodes = new();


            public BehaviorTree.Builder Selector()
            {
                IComposite lParent = GetParent();
                Selector lNewSelector = new();
                lParent.Add(lNewSelector);
                _nodes.Push(lNewSelector);

                return this;
            }

            public BehaviorTree.Builder Sequence()
            {
                IComposite lParent = GetParent();
                Sequence lNewSequence = new();
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

            public BehaviorTree.Builder Condition(AConditionNode pConditionNode)
            {
                IComposite lParent = GetParent();
                lParent.Add(pConditionNode);

                return this;
            }

            private IComposite GetParent()
            {
                if (_nodes.Count == 0)
                    return _brain.root;

                IComposite lParent = _nodes.Peek();

                return lParent ??= _brain.root;
            }

            public BehaviorTree Build()
            {
                return _brain;
            }

        }
    }
}
