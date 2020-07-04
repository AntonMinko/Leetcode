using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    146. LRU Cache

    Link: https://leetcode.com/problems/lru-cache/
    
    Difficulty: Medium
Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and put.

get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
put(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.

The cache is initialized with a positive capacity.

Follow up:
Could you do both operations in O(1) time complexity?
    
    */
    public class LRUCache
    {
        private class CacheEntry
        {
            public CacheEntry(int value, LinkedListNode<int> node)
            {
                Value = value;
                LruItemsNode = node;
            }
            public int Value { get; set; }
            public LinkedListNode<int> LruItemsNode { get; set; }
        }

        private readonly int _capacity;
        private readonly Dictionary<int, CacheEntry> _cache;
        private readonly LinkedList<int> _lruItems;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _cache = new Dictionary<int, CacheEntry>(_capacity);
            _lruItems = new LinkedList<int>();
        }

        public int Get(int key)
        {
            if (!_cache.ContainsKey(key)) return -1;

            var cachedValue = _cache[key];
            int value = cachedValue.Value;
            _lruItems.Remove(cachedValue.LruItemsNode);
            cachedValue.LruItemsNode = _lruItems.AddLast(key);

            return value;
        }

        public void Put(int key, int value)
        {
            if (_cache.ContainsKey(key))
            {
                _cache[key].Value = value;
                _lruItems.Remove(_cache[key].LruItemsNode);
                _cache[key].LruItemsNode = _lruItems.AddLast(key);
                return;
            }

            if (_lruItems.Count == _capacity)
            {
                int keyToRemove = _lruItems.First.Value;
                _cache.Remove(keyToRemove);
                _lruItems.RemoveFirst();
            }
            var node = _lruItems.AddLast(key);
            _cache.Add(key, new CacheEntry(value, node));
        }
    }

}