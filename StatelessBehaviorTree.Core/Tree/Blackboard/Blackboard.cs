// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

using System.Collections.Generic;
using System;
using System.Text;

namespace BehaviorTree.Core.Tree.Blackboard
{
    /// <summary>
    /// A class holding nodes or entities <b>states</b>. 
    /// </summary>
    public class Blackboard
    {
        private readonly Dictionary<string, object> _objectsByID = new Dictionary<string, object>();

        /// <summary>
        /// Provides a not blocking alternative to <see cref="Get{T}(BBKey{T})"/>
        /// </summary>
        /// <remarks>
        /// Use this if you want to add a fallback when a key is missing in the <see cref="Blackboard"/>. <br/>
        /// If you want to throw an exception if the key is missing, use <see cref="Get{T}(BBKey{T})"/> instead.
        /// </remarks>
        /// <typeparam name="T">Value's type</typeparam>
        /// <returns> returns <c>true</c> if tke key is present in the blackboard, otherwise returns <c>false</c> </returns>
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
            return false;
        }
        /// <summary>
        /// Get a value in the blackboard with a blackboard key. 
        /// </summary>
        /// 
        /// <remarks>
        /// This method is <b>type-safe</b>. Use this if you want to throw an exception if the key is missing. Otherwise, use <see cref="TryGet{T}(BBKey{T}, out T)"/>
        /// </remarks>
        /// 
        /// <typeparam name="T"></typeparam>
        /// <param name="pKey"></param>
        /// <exception cref="KeyNotFoundException"></exception>
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

        /// <summary>
        /// Get a value in the blackboard with a blackboard key. 
        /// </summary>
        /// <remarks> This method is <b>type-unsafe</b>. Only use this if you want to iterate fast.
        /// It is not recommanded to use this in production since nothing guarantee <typeparamref name="T"/> matches the value associated with the <paramref name="pKey"/> in the <see cref="Blackboard"/>. <br/>
        /// Use this if you want to throw an exception if the key is missing. Otherwise, use <see cref="Get{T}(string)"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="KeyNotFoundException"></exception>
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

        /// <summary>
        /// Provides a non-blocking alternative to <see cref="Get{T}(string)"/>
        /// </summary>
        /// <remarks>
        /// This method is <b>type-unsafe</b>. Only use this if you want to iterate fast.
        /// It is not recommanded to use this in production since nothing guarantee <typeparamref name="T"/> matches the value associated with the <paramref name="pKey"/> in the <see cref="Blackboard"/>. <br/>
        /// Use this if you want to add a fallback when a key is missing in the <see cref="Blackboard"/>. <br/>
        /// If you want to throw an exception if the key is missing, use <see cref="Get{T}(BBKey{T})"/> instead.
        /// </remarks>
        /// <typeparam name="T">Value's type</typeparam>
        /// <returns> returns <c>true</c> if tke key is present in the blackboard, otherwise returns <c>false</c> </returns>
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
