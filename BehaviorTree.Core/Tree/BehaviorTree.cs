// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Composite;
using BehaviorTree.Core.Node.Composite.Abstract;
using BehaviorTree.Core.Node.Decorator.Abstract;
using BehaviorTree.Core.Node.Leaf.Abstract;
using BehaviorTree.Core.Tree.Results;
using System;
using System.Collections.Generic;
using BB = BehaviorTree.Core.Tree.Blackboard.Blackboard;

namespace BehaviorTree.Core.Tree
{
    public class BehaviorTree : ANode
    {
        public AComposite? Root { get; set; }
        
        protected BehaviorTree() 
        {

        }
        public override TickResult Tick(BB pWorldContext, BB pMemory, ITickObserver? pTickOberver = null)
        {
            TickResult lResult = Root!.Tick(pWorldContext, pMemory, pTickOberver);
            pTickOberver?.OnTick(Root!, lResult);
            return lResult;
        }

        public class Builder
        {
            private readonly BehaviorTree _tree = new BehaviorTree();
            private readonly Stack<AComposite> _composites = new Stack<AComposite>();

            public BehaviorTree.Builder Selector(string pName = "")
            {
                Selector lNewSelector = new Selector(pName);

                if (_tree.Root == null)
                {
                    _tree.Root = lNewSelector;
                    return this;
                }

                AComposite lParent = GetParent();
                lParent.Add(lNewSelector);
                _composites.Push(lNewSelector);

                return this;
            }

            public BehaviorTree.Builder Sequence(string pName = "")
            {
                Sequence lNewSequence = new Sequence(pName);
                
                if (_tree.Root == null)
                {
                    _tree.Root = lNewSequence;
                    return this;
                }
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

            public BehaviorTree Build()
            {
                return _tree;
            }

        }
    }
}
