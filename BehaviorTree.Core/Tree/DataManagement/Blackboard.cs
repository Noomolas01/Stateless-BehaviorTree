using System.Collections.Generic;
using System;
namespace BehaviorTree.Core.Tree.DataManagement
{
    public class Blackboard
    {
        private readonly Dictionary<string, object> _memory = new Dictionary<string, object>();

        public bool Get<T>(BBKey<T> pKey, out T pValue)
        {
            if (_memory.TryGetValue(pKey.name, out object value))
            {
                if (value is T castValue)
                {
                    pValue = castValue;
                    return true;
                }
            }

            Console.WriteLine($"Key: {pKey.name} doesn't exist.");
            pValue = default!;
            return false;
        }

        public void Set<T>(BBKey<T> pKey, T pValue) where T :notnull
        {
            if (!_memory.ContainsKey(pKey.name))
            {
                Console.WriteLine($"Key: {pKey.name} added.");
            }

            _memory[pKey.name] = pValue!;
        }

        public void Remove<T>(BBKey<T> pKey)
        {
            if (!_memory.Remove(pKey.name))
            {
                Console.WriteLine($"Key: {pKey.name} doesn't exist.");
            }
        }
    }
}
