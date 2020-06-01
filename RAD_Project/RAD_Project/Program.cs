using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Numerics;
using System.Text;

namespace RAD_Project {
    internal class Program {
        public static void Main(string[] args) {
            int n = 100000;
            int l = 12;
            IEnumerable<Tuple<ulong, int>> stream = CreateStream1.CreateStream(n, l);
            MultiplyShiftHash shiftHash = new MultiplyShiftHash(l);
            MultiplyModPrimeHash modPrimeHash = new MultiplyModPrimeHash(l);
            FourUniHash fourUniHash = new FourUniHash();
            Stopwatch stopwatch = new Stopwatch();
            HashTable table = new HashTable(l);

            // Assignment 1.c
            stopwatch.Start();
            ulong shiftSum = 0;
            foreach ((ulong item1, _) in stream) {
                shiftSum += shiftHash.HashValue(item1);
            } 
            stopwatch.Stop();
            Console.WriteLine("Sum: {0} found in {1}", shiftSum, stopwatch.Elapsed);


            stopwatch.Reset();
            BigInteger modPrimeSum = 0;
            stopwatch.Start();
            foreach ((ulong item1, _) in stream) {
                modPrimeSum += modPrimeHash.HashValue(item1);
            }
            stopwatch.Stop();
            Console.WriteLine("Sum: {0} found in {1}", modPrimeSum, stopwatch.Elapsed);
            stopwatch.Reset();
            
            
            BigInteger fourSum = 0;
            stopwatch.Start();
            foreach ((ulong item1, _) in stream) {
                fourSum += fourUniHash.HashValue(item1);
            }
            stopwatch.Stop();
            Console.WriteLine("Sum: {0} found in {1}", fourSum, stopwatch.Elapsed);
            stopwatch.Reset();
            
            SquareSum sumCalculator = new SquareSum(table,stream);                        
            stopwatch.Start();                                                            
            int squareSum = sumCalculator.CalculateSum();                                 
            stopwatch.Stop();                                                             
            Console.WriteLine("Squaresum: {0} found in {1}",squareSum, stopwatch.Elapsed);
            BigInteger m = BigInteger.Pow(2, 4);
            stopwatch.Reset();

            BigInteger[] estimateArray = new BigInteger[100];
            var csv = new StringBuilder();
            for (int i = 0; i < estimateArray.Length; i++) {
                CountSketch countSketch = new CountSketch(m);
                foreach ((ulong item1, int item2) in stream) {
                    countSketch.Ci_Calculation(item1, item2);
                }

                var first = i.ToString();
                var second = countSketch.Approximation();
                var newLine = string.Format("{0},{1}", first, second);
                csv.AppendLine(newLine);
                
                
            }
            File.WriteAllText("money16.csv", csv.ToString());

            m = BigInteger.Pow(2, 7);
            var csv_1 = new StringBuilder();
            for (int i = 0; i < estimateArray.Length; i++) {
                CountSketch countSketch = new CountSketch(m);
                foreach ((ulong item1, int item2) in stream) {
                    countSketch.Ci_Calculation(item1, item2);
                }

                var first = i.ToString();
                var second = countSketch.Approximation();
                var newLine = string.Format("{0},{1}", first, second);
                csv_1.AppendLine(newLine);
                
                
            }
            

            File.WriteAllText("money128.csv", csv_1.ToString());
            
            m = BigInteger.Pow(2, 10);
            var csv_2 = new StringBuilder();
            for (int i = 0; i < estimateArray.Length; i++) {
                CountSketch countSketch = new CountSketch(m);
                foreach ((ulong item1, int item2) in stream) {
                    countSketch.Ci_Calculation(item1, item2);
                }

                var first = i.ToString();
                var second = countSketch.Approximation();
                var newLine = string.Format("{0},{1}", first, second);
                csv_2.AppendLine(newLine);
                
                
            }
            

            File.WriteAllText("money1024.csv", csv_2.ToString());



            /*
            BigInteger m = BigInteger.Pow(2, 28);
            CountSketch countSketch = new CountSketch(m);
            
            
            stopwatch.Reset();
            stopwatch.Start();
            foreach ((ulong item1, int item2) in stream) {
                countSketch.Ci_Calculation(item1, item2);
            }
            stopwatch.Stop();
            Console.WriteLine("Count-Sketch time elapsed: {0}", stopwatch.Elapsed);
            
            Console.WriteLine("Approximation: {0}", countSketch.Approximation());*/




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