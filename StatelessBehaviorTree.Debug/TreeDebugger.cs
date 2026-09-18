using StatelessBehaviorTree.Core.Node.Abstract;
using StatelessBehaviorTree.Core.Tree;
using StatelessBehaviorTree.Core.Tree.Blackboard;
using StatelessBehaviorTree.Core.Tree.Interfaces;
using StatelessBehaviorTree.Core.Tree.Results;
using System;
using System.Collections.Generic;

namespace StatelessBehaviorTree.Debug
{
    public class TreeDebugger : ITickHook
    {
        public readonly Dictionary<ARuntimeNode, DebugNode> debugNodeByRuntimeNode = new Dictionary<ARuntimeNode, DebugNode>();
        public readonly DebugNode root;
        public readonly BehaviorTree runtimeTree;
        public readonly Blackboard memory;


        public TreeDebugger(BehaviorTree pTree, Blackboard pBlackboard)
        {
            root = new DebugNode(pTree.Root!);
            debugNodeByRuntimeNode.Add(pTree.Root!, root);
            memory = pBlackboard;
            Init(root);
            runtimeTree = pTree;

        }

        public void OnTickStart(ARuntimeNode pRuntimeNode)
        {
            debugNodeByRuntimeNode[pRuntimeNode].result = new TickResult(NodeStatus.INACTIVE, null, memory);
        }

        public void OnTickEnd(ARuntimeNode pNode, TickResult pResult)
        {
            debugNodeByRuntimeNode[pNode].result = pResult;
        }

        public void Clean()
        {
            foreach(var key in debugNodeByRuntimeNode.Keys)
            {
                debugNodeByRuntimeNode[key].result = new TickResult(NodeStatus.INACTIVE, null, memory);
            }
        }

        private void Init(DebugNode pNodes)
        {
            if (pNodes.children == null || pNodes.children.Count == 0)
                return;

            foreach (var n in pNodes.children)
            {
                debugNodeByRuntimeNode.Add(n.runtimeNode, n);

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
