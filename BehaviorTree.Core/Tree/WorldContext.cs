using System.Collections.Generic;
using System;

namespace BehaviorTree.Core.Tree
{
    public class WorldContext
    {
        private readonly Dictionary<string, object?> _World = new Dictionary<string, object?>();

        public object? Get(string pKey)
        {
            if (_World.TryGetValue(pKey, out object? value))
            {
                return value;
            }

            Console.WriteLine($"Key: {pKey} doesn't exist.");
            return null;
        }

        public void Set<T>(string pKey, T pValue)
        {
            if (!_World.ContainsKey(pKey))
            {
                Console.WriteLine($"Key: {pKey} added.");
            }

            _World[pKey] = pValue;
        }
    }
}
