using System;
using System.Numerics;

namespace RAD_Project {
    public class MultiplyModPrimeHash {
        private BigInteger a = 
            "01010001011000100100000100110000000100000010111000000001101011111001001110100111001101011".NewBigInteger2();
        private BigInteger b =
            "01011000011010111100110111000001100001000001000101011000001110111101111000101000110000001".NewBigInteger2();

        private static int q = 89;
        private BigInteger p = BigInteger.Pow(2, MultiplyModPrimeHash.q);
        private int l;
        public MultiplyModPrimeHash(int l) {
            this.l = l;
        }

        public BigInteger HashValue(BigInteger x) {
            BigInteger x1 = (a * x + b);
            BigInteger y = (x1 & p) + (x1 >> MultiplyModPrimeHash.q);
            if (y > p) {
                y -= p;
            }
            return y % (BigInteger.Pow(2, l));
        }
    }
}