using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Schema;


//Code will not run, but trying to make a general skeleton for a hash table. 
namespace RAD_Project {
    public struct KeyVal<K, V> {
        public K Key { get; set; }
        public V Val { get; set; }
    }
    public class HashTable {
        public LinkedList<KeyVal<UInt64, int>>[] items;
        private int size;
        private MultiplyShiftHash hash;
        public HashTable(int l) {
            size = (int) Math.Pow(2, l);
            hash = new MultiplyShiftHash(l);
            items = new LinkedList<KeyVal<UInt64, int >>[size];
        }
        public int Get(UInt64 key) {
            UInt64 index = hash.HashValue(key);
            if (items[index] == null) {
                return 0;
            }
            foreach (KeyVal<UInt64, int> x in items[index]){
                if (x.Key == key) {
                    return x.Val;
                }
            }

            return 0;

        }

        public void Set(UInt64 key, int val) {
            UInt64 index = hash.HashValue(key);
            bool found = false;
            KeyVal<UInt64, int> newNode = new KeyVal<ulong, int> {Key = key, Val = val};
            if (items[index] == null) {
                items[index] = new LinkedList<KeyVal<UInt64, int>>();
                items[index].AddFirst(newNode);
                return;
            }
            for (LinkedListNode<KeyVal<ulong, int>> node = items[index].First;
                node != null;
                node = node.Next) {
                if (node.Value.Key.Equals(key)) {
                    items[index].AddBefore(node, newNode);
                    items[index].Remove(node);
                    found = true;
                }
            }

            if (!found) {
                items[index].AddLast(newNode);
            }
        }
        public void Increment(UInt64 key, int d) {
            UInt64 index = hash.HashValue(key);
            bool found = false;
            KeyVal<UInt64, int> newNode = new KeyVal<ulong, int> {Key = key, Val = d};
            if (items[index] == null) {
                items[index] = new LinkedList<KeyVal<UInt64, int>>();
                items[index].AddFirst(newNode);
                return;
            }
            for (LinkedListNode<KeyVal<ulong, int>> node = items[index].First;
                node != null;
                node = node.Next) {
                if (node.Value.Key.Equals(key)) {
                    newNode.Val += node.Value.Val;
                    items[index].AddBefore(node, newNode);
                    items[index].Remove(node);
                    found = true;
                }
            }

            if (!found) {
                items[index].AddLast(newNode);
            }
        }
    }
}