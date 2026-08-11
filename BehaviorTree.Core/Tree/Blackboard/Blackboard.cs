// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using System.Collections.Generic;
using System;
using System.Collections;

namespace BehaviorTree.Core.Tree.Blackboard
{
    public class Blackboard
    {
        private readonly Dictionary<string, object> _kvp = new Dictionary<string, object>();

        public bool Get<T>(BBKey<T> pKey, out T pValue)
        {
            if (_kvp.TryGetValue(pKey.name, out object value))
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
            if (!_kvp.ContainsKey(pKey.name))
            {
                Console.WriteLine($"Key: {pKey.name} added.");
            }

            _kvp[pKey.name] = pValue!;
        }

        public void Remove<T>(BBKey<T> pKey)
        {
            if (!_kvp.Remove(pKey.name))
            {
                Console.WriteLine($"Key: {pKey.name} doesn't exist.");
            }
        }

        public bool Get<T>(string pKey, out T pValue)
        {
            if (_kvp.TryGetValue(pKey, out object value))
            {
                if (value is T castValue)
                {
                    pValue = castValue;
                    return true;
                }
            }

            Console.WriteLine($"Key: {pKey} doesn't exist.");
            pValue = default!;
            return false;
        }

        public void Set<T>(string pKey, T pValue) where T : notnull
        {
            if (!_kvp.ContainsKey(pKey))
            {
                Console.WriteLine($"Key: {pKey} added.");
            }

            _kvp[pKey] = pValue!;
        }

        public void Remove<T>(string pKey)
        {
            if (!_kvp.Remove(pKey))
            {
                Console.WriteLine($"Key: {pKey} doesn't exist.");
            }
        }

    }
}
