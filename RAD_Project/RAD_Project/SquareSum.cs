using System;
using System.Collections.Generic;

namespace RAD_Project {
    public class SquareSum {
        private HashTable hTable;
        private IEnumerable<Tuple<ulong, int>> keyStream;

        public SquareSum(HashTable table, IEnumerable<Tuple<ulong, int>> stream) {
            hTable = table;
            keyStream = stream;
        }

        private void PopulateTable() {
            foreach ((ulong item1, int item2) in keyStream) {
                hTable.Increment(item1, item2);
            }
        }
        
        public int CalculateSum() {
            PopulateTable();
            int sum = 0;
            foreach (LinkedList<KeyVal<ulong,int>> x in hTable.items) {
                if (x != null) {
                    foreach (KeyVal<ulong, int> x1 in x) {
                        Console.WriteLine("Key: {0}, Val: {1}",x1.Key, x1.Val);
                    }
                }
            }
            foreach ((ulong item1, _) in keyStream) {
                int value = hTable.Get(item1);
                sum += value * value;
            }

            return sum;
        }
    }
}