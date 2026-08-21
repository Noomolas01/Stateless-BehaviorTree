// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using System.Collections.Generic;
using System;
using System.Collections;
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

            Console.WriteLine($"Key: {pKey.name} doesn't exist.");
            pValue = default!;
            return false;
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

            throw new Exception($"Key: {pKey.name} doesn't exist.");
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

            throw new Exception($"Key: {pKey} doesn't exist.");
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
                Console.WriteLine($"Key: {pKey.name} doesn't exist.");
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

            Console.WriteLine($"Key: {pKey} doesn't exist.");
            pValue = default!;
            return false;
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
                Console.WriteLine($"Key: {pKey} doesn't exist.");
            }
        }

        public override string ToString()
        {
            StringBuilder lSb = new StringBuilder();

            foreach (var kvp in _objectsByID)
            {
                string lKvpString = $"{kvp.Key} : {kvp.Value}";
                lSb.AppendLine(lKvpString);
            }

            return lSb.ToString();
        }
    }
}
