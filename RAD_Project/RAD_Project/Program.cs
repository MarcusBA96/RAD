using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace RAD_Project {
    internal class Program {
        public static void Main(string[] args) {
            int n = 1000;
            int l = 8;
            IEnumerable <Tuple <ulong , int >> stream = CreateStream1.CreateStream(n,l);
            MultiplyShiftHash shiftHash = new MultiplyShiftHash(49);
            MultiplyModPrimeHash modPrimeHash = new MultiplyModPrimeHash(34);
            HashTable table = new HashTable(l);
            ulong[] keyArray = new ulong[(int) Math.Pow(2,l)];

            ulong shiftSum = 0;
            foreach ((ulong item1, int item2) in stream) {
                shiftSum += shiftHash.HashValue(item1);
            }
            //Console.WriteLine(shiftSum);

            int streamSum = 0;
            foreach ((ulong item1, int item2) in stream) {
                keyArray[item1] = item1;
                streamSum += item2;
                table.Increment(item1, item2);
            }

            int getSum = 0;
            foreach (ulong x in keyArray) {
                getSum += table.Get(x);
            }
            Console.WriteLine(streamSum);
            Console.WriteLine(getSum);

            int counter = 0;
            int falseCounter = 0;
            foreach ((ulong item1, int item2) in stream) {
                if (table.Get(item1) == item2) {
                    counter++;
                } else {
                    falseCounter++;
                }
            }
            //Console.WriteLine(counter);
            //Console.WriteLine(falseCounter);
            
            table.Set(34, 25);
            table.Increment(34, 25);
            //Console.WriteLine(table.Get(34));
        }
    }
}