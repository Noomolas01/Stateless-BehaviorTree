// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Interfaces;
using BehaviorTree.Core.Tree.Results;

namespace BehaviorTree.Core.Node.Abstract
{
    /// <summary>
    /// Base class for every tree or tree's node
    /// </summary>
    public abstract class ANode
    {
        public readonly string name;

        public ANode(string pName = "")
        {
            name = pName;
        }

        public abstract TickResult Tick(Blackboard pWorldContext, Blackboard pMemory, ITickObserver? pTickOberver = null);

    }
}