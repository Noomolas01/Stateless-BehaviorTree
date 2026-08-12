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
        public readonly ANode runtimeNode;
        public IReadOnlyList<DebugNode>? children = null;
        public TickResult result;

        public DebugNode(ANode pRuntimeNode)
        {
            id = pRuntimeNode.name;
            runtimeNode = pRuntimeNode;
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
            tree.Add(pTree.root, _root);
            Init(_root);
        }

        public void OnTick(ANode pNode, TickResult pResult)
        {
            tree[pNode].result = pResult;
            
            Console.WriteLine($"{pNode.name} has been ticked with the result : {pResult}");
        }
        
        private void Init(DebugNode pNodes)
        {
            if (pNodes.children == null || pNodes.children.Count == 0 )
                return;

            foreach (var n in pNodes.children)
            {
                tree.Add(n.runtimeNode, n);

                if (n.children != null && n.children.Count > 0)
                {
                    Init(n);
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
