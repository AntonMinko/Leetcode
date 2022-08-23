using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    460. LFU Cache

    Link: https://leetcode.com/problems/lfu-cache/
    
    Difficulty: Hard

Design and implement a data structure for a Least Frequently Used (LFU) cache.

Implement the LFUCache class:
    LFUCache(int capacity) Initializes the object with the capacity of the data structure.
    int get(int key) Gets the value of the key if the key exists in the cache. Otherwise, returns -1.
    void put(int key, int value) Update the value of the key if present, or inserts the key if not
        already present. When the cache reaches its capacity, it should invalidate and remove
        the least frequently used key before inserting a new item. For this problem, when there
        is a tie (i.e., two or more keys with the same frequency), the least recently used key
        would be invalidated.

To determine the least frequently used key, a use counter is maintained for each key in the cache. 
The key with the smallest use counter is the least frequently used key.
When a key is first inserted into the cache, its use counter is set to 1 (due to the put operation).
The use counter for a key in the cache is incremented either a get or put operation is called on it.
The functions get and put must each run in O(1) average time complexity.

Example 1:

Input
["LFUCache", "put", "put", "get", "put", "get", "get", "put", "get", "get", "get"]
[[2], [1, 1], [2, 2], [1], [3, 3], [2], [3], [4, 4], [1], [3], [4]]
Output
[null, null, null, 1, null, -1, 3, null, -1, 3, 4]

Explanation
// cnt(x) = the use counter for key x
// cache=[] will show the last used order for tiebreakers (leftmost element is  most recent)
LFUCache lfu = new LFUCache(2);
lfu.put(1, 1);   // cache=[1,_], cnt(1)=1
lfu.put(2, 2);   // cache=[2,1], cnt(2)=1, cnt(1)=1
lfu.get(1);      // return 1
                 // cache=[1,2], cnt(2)=1, cnt(1)=2
lfu.put(3, 3);   // 2 is the LFU key because cnt(2)=1 is the smallest, invalidate 2.
                 // cache=[3,1], cnt(3)=1, cnt(1)=2
lfu.get(2);      // return -1 (not found)
lfu.get(3);      // return 3
                 // cache=[3,1], cnt(3)=2, cnt(1)=2
lfu.put(4, 4);   // Both 1 and 3 have the same cnt, but 1 is LRU, invalidate 1.
                 // cache=[4,3], cnt(4)=1, cnt(3)=2
lfu.get(1);      // return -1 (not found)
lfu.get(3);      // return 3
                 // cache=[3,4], cnt(4)=1, cnt(3)=3
lfu.get(4);      // return 4
                 // cache=[4,3], cnt(4)=2, cnt(3)=3

Constraints:
    0 <= capacity <= 104
    0 <= key <= 105
    0 <= value <= 109
    At most 2 * 105 calls will be made to get and put.

    */
    public class LFUCache
    {
        class CachedItem
        {
            public CachedItem(int key, int value)
            {
                Key = key;
                Value = value;
                Frequency = 1;
            }

            public int Key { get; private set; }
            public int Value { get; set; }
            public int Frequency { get; set; }
        }

        private readonly Dictionary<int, LinkedListNode<CachedItem>> _cache = new();
        private readonly Dictionary<int, LinkedList<CachedItem>> _frequencies = new();
        private readonly int _capacity;
        private int _size;
        private int _minFrequency;

        public LFUCache(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (!_cache.ContainsKey(key)) return -1;

            var node = _cache[key];
            UpdateFrequencies(node, isNewNode: false);
            return node.Value.Value;
        }

        public void Put(int key, int value)
        {
            if (_capacity == 0) return;

            if (_cache.ContainsKey(key))
            {
                UpdateExistingItem(key, value);
                return;
            }

            InsertNewItem(key, value);
        }

        private void UpdateExistingItem(int key, int value)
        {
            var existingNode = _cache[key];
            existingNode.Value.Value = value;
            UpdateFrequencies(existingNode, isNewNode: false);
        }

        private void InsertNewItem(int key, int value)
        {
            if (_size == _capacity)
            {
                Evict();    // free room for the new item
            }

            var node = new LinkedListNode<CachedItem>(new CachedItem(key, value));
            _cache[key] = node;
            UpdateFrequencies(node, isNewNode: true);
            _size++;
            _minFrequency = 1; // just added a new cached item with frequency counter == 1
        }

        private void Evict()
        {
            var lruList = _frequencies[_minFrequency];
            var nodeToRemove = lruList.First;
            lruList.Remove(nodeToRemove);
            _cache.Remove(nodeToRemove.Value.Key);
            _size--;
        }

        private void UpdateFrequencies(LinkedListNode<CachedItem> node, bool isNewNode)
        {
            var cachedItem = node.Value;

            if (isNewNode)
            {
                _minFrequency = 1;
            }
            else
            {
                // existing node: increment its frequency and adjust _minFrequency if needed
                _frequencies[cachedItem.Frequency].Remove(node);
                if (_frequencies[cachedItem.Frequency].Count == 0 && cachedItem.Frequency == _minFrequency)
                {
                    _minFrequency++;
                }

                cachedItem.Frequency++;
            }

            // Add this node to _frequncies dictionary
            if (!_frequencies.ContainsKey(cachedItem.Frequency))
            {
                _frequencies[cachedItem.Frequency] = new LinkedList<CachedItem>();
            }

            _frequencies[cachedItem.Frequency].AddLast(node);
        }
    }
}