using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Node.Composite.Abstract;
using BehaviorTree.Core.Tree.Results;
using System.Collections.Generic;


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
            if (pRuntimeNode is AComposite lComposite)
                InitChildren(lComposite);
            
        }

        public void InitChildren(AComposite pComposite)
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
}
