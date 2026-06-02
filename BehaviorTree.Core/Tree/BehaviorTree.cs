using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Composite;
using BehaviorTree.Core.Node.Interfaces;

namespace BehaviorTree.Core.Tree
{
    public sealed class AIBrain : ANode
    {
        private readonly Selector root = new();
        //private AIBrain() { }

        public override Result Tick()
        {
            return root.Tick();
        }

        public class Builder
        {
            private readonly AIBrain _brain = new();
            private readonly Stack<IComposite> _nodes = new();


            public AIBrain.Builder Selector()
            {
                IComposite lParent = GetParent();
                Selector lNewSelector = new();
                lParent.Add(lNewSelector);
                _nodes.Push(lNewSelector);

                return this;
            }

            public AIBrain.Builder Sequence()
            {
                IComposite lParent = GetParent();
                Sequence lNewSequence = new();
                lParent.Add(lNewSequence);
                _nodes.Push(lNewSequence);

                return this;
            }

            public AIBrain.Builder End()
            {
                _nodes.Pop();
                return this;
            }

            public AIBrain.Builder Action(AActionNode pActionNode)
            {
                IComposite lParent = GetParent();
                lParent.Add(pActionNode);

                return this;
            }

                public AIBrain.Builder Condition(AConditionNode pConditionNode)
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

            public AIBrain Build()
            {
                return _brain;
            }

        }
    }
}
