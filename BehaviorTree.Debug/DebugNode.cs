using BehaviorTree.Core;
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Composite.Interfaces;
using BehaviorTree.Core.Tree;
using BehaviorTree.Core.Tree.Results;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BehaviorTree.Debug
{
    public class DebugNode
    {
        public readonly string id;
        public IReadOnlyList<DebugNode>? children = null;
        public TickResult result;

        public DebugNode(ANode pRuntimeNode)
        {
            id = pRuntimeNode.name;

            if (pRuntimeNode is IComposite lComposite)
                InitChildren(lComposite);
            
        }

        public void InitChildren(IComposite pComposite)
        {
            if (pComposite == null || pComposite.Children.Count == 0) 
                return;

            List<DebugNode> lChildren = new List<DebugNode>();
            foreach (var n in pComposite.Children)
            {
                lChildren.Add(new DebugNode(n));
            }

            children = lChildren.AsReadOnly();
        }
    }

    public class DebugTree : ITickObserver
    {
        public readonly Dictionary<ANode, DebugNode> tree = new Dictionary<ANode,DebugNode>();
        private readonly DebugNode _root;

        public DebugTree(Core.Tree.BehaviorTree pTree)
        {
            _root = new DebugNode(pTree.root);
            Init(pTree.root.Children);
        }

        public void OnTick(ANode pNode, TickResult pResult)
        {
            tree[pNode].result = pResult;
            Console.WriteLine($"{pNode.name} has been ticked with the result : {pResult}");
        }

        private void Init(List<ANode> nodes)
        {
            foreach (var n in nodes)
            {
                DebugNode lDebugNode = new DebugNode(n);
                tree.Add(n, lDebugNode);

                if (n is IComposite lComposite)
                {
                    Init(lComposite.Children);
                }
            }
        }

        public void Traverse()
        {
            Traverse(_root);
        }

        private void Traverse(DebugNode pRoot)
        {
            Console.WriteLine(pRoot.id);
            Console.WriteLine("It contains:" + tree.ContainsValue(pRoot));

            if (pRoot.children != null)
            {
                foreach(var n in pRoot.children)
                {
                    Traverse(n);
                }
            }
        }
    
    }
}
