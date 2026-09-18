// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

namespace StatelessBehaviorTree.Core.Tree.Blackboard
{
    /// <summary>
    /// Regroups a type and a name as a key for a type-safe access to <see cref="Blackboard"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BBKey<T>
    {
        public readonly string name;

        public BBKey(string pName)
        {
            name = pName;
        }
    }
}