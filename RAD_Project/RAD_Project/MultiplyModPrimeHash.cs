using System;
using System.Numerics;

namespace RAD_Project {
    public class MultiplyModPrimeHash {
        private BigInteger a = 
            BigInteger.Parse("0b01010001011000100100000100110000000100000010111000000001101011111001001110100111001101011");
        private BigInteger b =
            BigInteger.Parse("0b01011000011010111100110111000001100001000001000101011000001110111101111000101000110000001");
        private static int q = 89;
        private BigInteger p = BigInteger.Pow(2, MultiplyModPrimeHash.q);
        private int l;
        private UInt64 key;
        public MultiplyModPrimeHash(int l, UInt64 x) {
            this.key = x;
            this.l = l;
        }
        public 
    }
}