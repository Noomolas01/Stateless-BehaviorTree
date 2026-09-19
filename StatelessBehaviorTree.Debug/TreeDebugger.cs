using StatelessBehaviorTree.Core.Node.Abstract;
using StatelessBehaviorTree.Core.Node.Composite.Abstract;
using StatelessBehaviorTree.Core.Tree;
using StatelessBehaviorTree.Core.Tree.Data;
using StatelessBehaviorTree.Core.Tree.Interfaces;
using StatelessBehaviorTree.Core.Tree.Results;
using System;
using System.Collections.Generic;

namespace StatelessBehaviorTree.Debug
{
    public class TreeDebugger : ITickHook
    {
        public readonly Dictionary<ARuntimeNode, DebugNode> debugNodeByRuntimeNode = new Dictionary<ARuntimeNode, DebugNode>();
        public DebugNode? Root {get; private set;}

        private BehaviorTree runtimeTree;


        public void OnTickStart(ARuntimeNode pRuntimeNode, Blackboard pMemory)
        {
            debugNodeByRuntimeNode[pRuntimeNode].isActive = true;
        }

        public void OnTickEnd(ARuntimeNode pNode, TickResult pResult)
        {
            debugNodeByRuntimeNode[pNode].result = pResult;

        }

        public void Clean()
        {
            foreach (var key in debugNodeByRuntimeNode.Keys)
            {
                debugNodeByRuntimeNode[key].isActive = false;
            }
        }

        private void InitDebugNodes(DebugNode pNodes)
        {
            if (pNodes.children == null || pNodes.children.Count == 0)
                return;

            foreach (var n in pNodes.children)
            {
                debugNodeByRuntimeNode.Add(n.runtimeNode, n);

                if (n.children != null && n.children.Count > 0)
                {
                    InitDebugNodes(n);
                }
            }
        }

        public void Traverse()
        {
            Traverse(Root);
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

        public void Init(ARuntimeNode pRoot)
        {
            Root = new DebugNode(pRoot!);
            debugNodeByRuntimeNode.Add(pRoot!, Root);
            InitDebugNodes(Root);
            //runtimeTree = pTree;
        }
    }
}
