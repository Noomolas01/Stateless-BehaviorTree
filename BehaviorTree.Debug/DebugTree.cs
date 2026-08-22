using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Interfaces;
using BehaviorTree.Core.Tree.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviorTree.Debug
{
    public class DebugTree : Core.Tree.BehaviorTree, ITickObserver
    {
        public readonly Dictionary<ANode, DebugNode> tree = new Dictionary<ANode, DebugNode>();
        public readonly DebugNode root;
        public readonly Blackboard memory;

        public readonly Core.Tree.BehaviorTree runtimeTree;

        public DebugTree(Core.Tree.BehaviorTree pTree, Blackboard pBlackboard)
        {
            root = new DebugNode(pTree.Root!);
            tree.Add(pTree.Root!, root);
            memory = pBlackboard;
            Init(root);
            runtimeTree = pTree;

        }

        public override TickResult Tick(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickOberver = null)
        {
            return runtimeTree.Tick(pWorldContext, pMemory, this);
        }

        public void OnTickStart(ANode pNode)
        {
            tree[pNode].result = new TickResult(NodeStatus.INACTIVE, null, memory);
        }

        public void OnTickEnd(ANode pNode, TickResult pResult)
        {
            tree[pNode].result = pResult;
        }

        public void Clean()
        {
            foreach(var key in tree.Keys)
            {
                tree[key].result = new TickResult(NodeStatus.INACTIVE, null, memory);
            }
        }

        private void Init(DebugNode pNodes)
        {
            if (pNodes.children == null || pNodes.children.Count == 0)
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
            Traverse(root);
        }

        public string GetMemory()
        {
            return memory.ToString();
        }

        private void Traverse(DebugNode pNode)
        {
            Console.WriteLine(pNode.id);
            if (pNode.children != null)
            {
                foreach (var n in pNode.children)
                {
                    Traverse(n);
                }
            }
        }

    }
}
