// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;
using System;
using System.Collections.Generic;

namespace BehaviorTree.Core.Node.Composite.Interfaces
{
    [Obsolete]
    internal interface IComposite
    {
        public List<ANode> Children { get; }
        public TickResult ProcessChildren(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickObserver = null);
        public void Add(ANode pNode);
    }

}