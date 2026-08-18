using BehaviorTree.Core.Node.Leaf.Abstract;
using BehaviorTree.Core.Tree.Blackboard;
using BehaviorTree.Core.Tree.Results;


namespace BehaviorTree.Core.Node.Leaf
{
    public class SetProperty<T> : AActionNode where T : notnull
    {
        private readonly string _key;
        private readonly T _value;

        public SetProperty(string pKey, T pValue) 
        {
            _key = pKey;
            name = "SetProperty " + _key;
            _value = pValue;
        }

        protected override TickResult Do(Blackboard pWorldContext, Blackboard pMemory)
        {
           pMemory.Set(_key, _value!);

            return new TickResult(NodeStatus.SUCCESS, null, pMemory);

        }
    }
}
