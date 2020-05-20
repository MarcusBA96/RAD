using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


//Code will not run, but trying to make a general skeleton for a hash table. 
namespace RAD_Project {
    public class HashTable<TKey, TVal> {
        private LinkedList<Tuple<TKey, TVal>>[] items;
        private readonly int size;
        private readonly int l;
        private object hasher = new MultiplyShiftHash();
        public HashTable(int l) {
            l = l;
            size = (int) Math.Pow(2, l);
            items = new LinkedList<Tuple<TKey, TVal>>[size];
        }

        
        public void Get(TKey) {
            int index = hasher.HashValue(TKey) % size;
            if (items[index] == 0) {
                return 0;
            } else {
                return items[index];
            }
        }

        public void set(TKey, TVal) {
            
        }
    }
}