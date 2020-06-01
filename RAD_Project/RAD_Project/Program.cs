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
            stopwatch.Reset();
            
            //Oppgave 3
            var csvSum = new StringBuilder();
            var newLine = "l,sumShift, timeShift, sumPrime, timePrime";
            csvSum.AppendLine(newLine);
            for (int i = 2; i < 30; i += 2) {
                IEnumerable<Tuple<ulong, int>> streaming = CreateStream1.CreateStream(n, i);
                HashTable tableShift = new HashTable(i);
                HashTablePrime tablePrime = new HashTablePrime(i);
                SquareSum sumShift = new SquareSum(tableShift, streaming);
                SquareSumPrime sumPrime = new SquareSumPrime(tablePrime, streaming);
                stopwatch.Start();
                int squareSumShift = sumShift.CalculateSum();
                stopwatch.Stop();
                var squareSumTime = stopwatch.Elapsed;
                stopwatch.Reset();
                stopwatch.Start();
                int squareSumPrime = sumShift.CalculateSum();
                stopwatch.Stop();
                var squareSumPTime = stopwatch.Elapsed;
                stopwatch.Reset();
                
                var theL = i.ToString();
                var sumShiftVal = squareSumShift.ToString();
                var sumShiftTime = squareSumTime.ToString();
                var sumPrimeVal = squareSumPrime.ToString();
                var sumPrimeTime = squareSumPTime.ToString();
                var line = string.Format("{0},{1},{2},{3},{4}", theL, sumShiftVal, sumShiftTime,
                    sumPrimeVal, sumPrimeTime);
                csvSum.AppendLine(line);
            }
            File.WriteAllText("SquareSumTime.csv", csvSum.ToString());
            //m = 16
            BigInteger m = BigInteger.Pow(2, 4);
            CountSketch countSketch16 = new CountSketch(m);
            foreach ((ulong item1, int item2) in stream) {
                countSketch16.Ci_Calculation(item1, item2);
            }
            stopwatch.Start();
            BigInteger approx_16 = countSketch16.Approximation();
            stopwatch.Stop();
            Console.WriteLine("Approximation m = 16: {0}, Time elapsed:   {1}",approx_16, stopwatch.Elapsed);
            stopwatch.Reset();
            
            BigInteger[] estimateArray = new BigInteger[100];
            /*var csv = new StringBuilder();
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
            File.WriteAllText("money16.csv", csv.ToString());*/

            //m = 128
            m = BigInteger.Pow(2, 7);
            CountSketch countSketch128 = new CountSketch(m);
            foreach ((ulong item1, int item2) in stream) {
                countSketch128.Ci_Calculation(item1, item2);
            }
            stopwatch.Start();
            BigInteger approx_128 = countSketch128.Approximation();
            stopwatch.Stop();
            Console.WriteLine("Approximation m = 128: {0}, Time elapsed:  {1}", approx_128,stopwatch.Elapsed);
            stopwatch.Reset();
            
            /*
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
            */
            
            //m = 1024
            m = BigInteger.Pow(2, 10);
            CountSketch countSketch1024 = new CountSketch(m);
            foreach ((ulong item1, int item2) in stream) {
                countSketch1024.Ci_Calculation(item1, item2);
            }
            stopwatch.Start();
            BigInteger approx_1024 = countSketch1024.Approximation();
            stopwatch.Stop();
            Console.WriteLine("Approximation m = 1024: {0}, Time elapsed: {1}",approx_1024, stopwatch.Elapsed);
            stopwatch.Reset();
            /*var csv_2 = new StringBuilder();
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
            

            File.WriteAllText("money1024.csv", csv_2.ToString());*/


        }
    }
}