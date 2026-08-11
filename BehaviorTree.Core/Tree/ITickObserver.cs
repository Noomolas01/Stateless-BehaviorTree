using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviorTree.Core.Tree
{
   public interface ITickObserver
    {
        void OnTick(ANode pNode, TickResult pResult);
    }
}
