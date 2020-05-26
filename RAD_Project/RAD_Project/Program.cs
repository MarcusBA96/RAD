using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace RAD_Project {
    internal class Program {
        public static void Main(string[] args) {
            int n = 100000;
            int l = 10;
            IEnumerable <Tuple <ulong , int >> stream = CreateStream1.CreateStream(n,l);
            MultiplyShiftHash shiftHash = new MultiplyShiftHash(49);
            MultiplyModPrimeHash modPrimeHash = new MultiplyModPrimeHash(34);
            Stopwatch stopwatch = new Stopwatch();
            HashTable table = new HashTable(l);
            ulong[] keyArray = new ulong[(int) Math.Pow(2,l)];
            
            // Assignment 1.c
            stopwatch.Start();
            ulong shiftSum = 0;
            foreach ((ulong item1, int item2) in stream) {
                shiftSum += shiftHash.HashValue(item1);
            }
            stopwatch.Stop();
            Console.WriteLine("Sum: {0} found in {1}", shiftSum, stopwatch.Elapsed);
            

            stopwatch.Reset();
            BigInteger modPrimeSum = 0;
            stopwatch.Start();
            foreach ((ulong item1, int item2) in stream) {
                modPrimeSum += modPrimeHash.HashValue(item1);
            }
            stopwatch.Stop();
            Console.WriteLine("Sum: {0} found in {1}", modPrimeSum, stopwatch.Elapsed);
            
            stopwatch.Reset();
            SquareSum sumCalculator = new SquareSum(table,stream);
            stopwatch.Start();
            int squareSum = sumCalculator.CalculateSum();
            stopwatch.Stop();
            Console.WriteLine("Squaresum: {0} found in {1}",squareSum, stopwatch.Elapsed);

            UInt64 m = (UInt64) BigInteger.Pow(2, 24);
            
            CountSketch countSketch = new CountSketch(m);
            
            stopwatch.Reset();
            stopwatch.Start();
            foreach ((ulong item1, int item2) in stream) {
                countSketch.Ci_Calculation(item1, item2);
            }
            stopwatch.Stop();
            Console.WriteLine("Approximation: {0}, time elapsed: {1}", countSketch.Approximation(), stopwatch.Elapsed);




            /*int streamSum = 0;
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
            //Console.WriteLine(table.Get(34));*/
        }
    }
}