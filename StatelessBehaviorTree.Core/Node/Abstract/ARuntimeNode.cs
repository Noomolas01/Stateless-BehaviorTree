// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using StatelessBehaviorTree.Core.Tree.Data;
using StatelessBehaviorTree.Core.Tree.Interfaces;
using StatelessBehaviorTree.Core.Tree.Results;

namespace StatelessBehaviorTree.Core.Node.Abstract
{
    /// <summary>
    /// Base class for every object that can be store inside a <see cref="Tree.BehaviorTree"/>
    /// </summary>
    public abstract class ARuntimeNode
    {
        public readonly string name;

        public ARuntimeNode(string pName = "")
        {
            name = pName;
        }

        /// <summary>
        /// Consumes data and produce a <see cref="TickResult"/>.
        /// </summary>
        /// <remarks>
        /// Every class that inherits from <see cref="ARuntimeNode"/> will "tick" differently.
        /// </remarks>
        /// <param name="pWorldContext">Data shared among trees</param>
        /// <param name="pMemory">Data shared among nodes</param>
        /// <param name="pTickHook"></param>
        /// <returns>Returns a <see cref="TickResult"/> </returns>
        public abstract TickResult Tick(Blackboard pWorldContext, Blackboard pMemory, ITickHook? pTickHook = null);

    }
}