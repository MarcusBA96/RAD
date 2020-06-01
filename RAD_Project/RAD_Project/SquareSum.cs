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
                        int value = x1.Val;
                        sum += value * value;
                        //Console.WriteLine("Get correct: {0}",x1.Val==hTable.Get(x1.Key));
                    }
                }
            }

            return sum;
        }
    }
}