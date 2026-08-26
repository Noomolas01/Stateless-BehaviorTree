// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using System.Collections.Generic;
using System;
using System.Text;

namespace BehaviorTree.Core.Tree.Blackboard
{
    public class Blackboard
    {
        private readonly Dictionary<string, object> _objectsByID = new Dictionary<string, object>();

        public bool TryGet<T>(BBKey<T> pKey, out T pValue)
        {
            if (_objectsByID.TryGetValue(pKey.name, out object value))
            {
                if (value is T castValue)
                {
                    pValue = castValue;
                    return true;
                }
            }

            pValue = default!;
            throw new KeyNotFoundException($"Key: {pKey.name} doesn't exist.");
        }

        public T Get<T>(BBKey<T> pKey)
        {
            if (_objectsByID.TryGetValue(pKey.name, out object value))
            {
                if (value is T castValue)
                {
                    return castValue;
                }
            }

            throw new KeyNotFoundException($"Key: {pKey.name} doesn't exist.");
        }
        public T Get<T>(string pKey)
        {
            if (_objectsByID.TryGetValue(pKey, out object value))
            {
                if (value is T castValue)
                {
                    return castValue;
                }
            }

            throw new KeyNotFoundException($"Key: {pKey} doesn't exist.");
        }

        public void Set<T>(BBKey<T> pKey, T pValue) where T :notnull
        {
            if (!_objectsByID.ContainsKey(pKey.name))
            {
                Console.WriteLine($"Key: {pKey.name} added.");
            }

            _objectsByID[pKey.name] = pValue!;
        }

        public void Remove<T>(BBKey<T> pKey)
        {
            if (!_objectsByID.Remove(pKey.name))
            {
                throw new KeyNotFoundException($"Key: {pKey.name} doesn't exist.");
            }
        }

        public bool TryGet<T>(string pKey, out T pValue)
        {
            if (_objectsByID.TryGetValue(pKey, out object value))
            {
                if (value is T castValue)
                {
                    pValue = castValue;
                    return true;
                }
            }

            pValue = default!;
            throw new KeyNotFoundException($"Key: {pKey} doesn't exist.");
        }

        public void Set<T>(string pKey, T pValue) where T : notnull
        {
            if (!_objectsByID.ContainsKey(pKey))
            {
                Console.WriteLine($"Key: {pKey} added.");
            }

            _objectsByID[pKey] = pValue!;
        }

        public void Remove<T>(string pKey)
        {
            if (!_objectsByID.Remove(pKey))
            {
                throw new KeyNotFoundException($"Key: {pKey} doesn't exist.");
            }
        }

        public override string ToString()
        {
            StringBuilder lSb = new StringBuilder();

            foreach (var kvp in _objectsByID)
            {
                lSb.Append(kvp.Key).Append(" : ").Append(kvp.Value).AppendLine() ;
            }

            return lSb.ToString();
        }
    }
}
