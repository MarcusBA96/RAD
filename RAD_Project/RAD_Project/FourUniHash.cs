using System;
using System.Numerics;

namespace RAD_Project {
    public class FourUniHash {
        private BigInteger a_0 =
            BigInteger.Parse(
                "01010001011000100100000100110000000100000010111000000001101011111001001110100111001101011");

        private BigInteger a_1 =
            BigInteger.Parse(
                "11001110111010000010001011101000111010100110000010010000111001101000000101011111011111111");

        private BigInteger a_2 =
            BigInteger.Parse(
                "00100100001001101011000101100111100011110011110100100011010111001010101101000111111001101");

        private BigInteger a_3 =
            BigInteger.Parse(
                "01011000011010111100110111000001100001000001000101011000001110111101111000101000110000001");
        private static int q = 89;
        private BigInteger p = BigInteger.Pow(2, FourUniHash.q ) - 1;

        public BigInteger HashValue(BigInteger x) {
            BigInteger x1 = 
                a_0 + a_1 * (x) + a_2 * BigInteger.Pow(x,2) + a_3 * BigInteger.Pow(x,3);
            BigInteger y = (x1 & p) + (x1 >> FourUniHash.q);
            if (y >= p) {
                y -= p;
            }

            return y;
        }
    }
}