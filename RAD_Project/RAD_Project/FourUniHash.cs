using System;
using System.Numerics;

namespace RAD_Project {
    public class FourUniHash {
        public BigInteger[] a_array = RandomBits.RandomArray(4);
        private static int q = 89;
        private BigInteger p = BigInteger.Pow(2, FourUniHash.q ) - 1;
        
        public BigInteger HashValue(BigInteger x) {
            int q_index = a_array.Length;
            BigInteger y = a_array[q_index - 1];
            for (int i = q_index - 2; i >= 0; i--) {
                y = y * x + a_array[i];
                y = (y & p) + (y >> FourUniHash.q);
            }
            if (y >= p) {
                y -= p;
            }
            return y;
        }
    }
}