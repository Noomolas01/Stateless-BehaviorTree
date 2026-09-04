// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

namespace StatelessBehaviorTree.Core.Tree.Blackboard
{
    public class BBKey<T>
    {
        public readonly string name;

        public BBKey(string pName)
        {
            name = pName;
        }
    }
}