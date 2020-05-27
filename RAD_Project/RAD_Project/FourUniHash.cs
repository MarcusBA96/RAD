using System;
using System.Numerics;

namespace RAD_Project {
    public class FourUniHash {
        private BigInteger[] a_array = RandomBits.RandomArray(4);
        /*{
            "01010001011000100100000100110000000100000010111000000001101011111001001110100111001100011".NewBigInteger2(),
            "01010001011000100100000100110000000100000010111000000001101011111001001110100111001100011".NewBigInteger2(),
            "00100100001001101011000101100111100011110011110100100011010111001010101101000111111000101".NewBigInteger2(),
            "01011000011010111100110111000001100001000001000101011000001110111101111000101000110000001".NewBigInteger2()
        };*/
        /*private BigInteger a0 =
            BigInteger.Parse(
                "01010001011000100100000100110000000100000010111000000001101011111001001110100111001100011");

        private BigInteger a1 =
            BigInteger.Parse(
                "11001110111010000010001011101000111010100110000010010000111001101000000101011111011111011");

        private BigInteger a2 =
            BigInteger.Parse(
                "00100100001001101011000101100111100011110011110100100011010111001010101101000111111000101");

        private BigInteger a3 =
            BigInteger.Parse(
                "01011000011010111100110111000001100001000001000101011000001110111101111000101000110000001");*/
        private static int q = 89;
        private BigInteger p = BigInteger.Pow(2, FourUniHash.q ) - 1;

        public BigInteger HashValue(BigInteger x) {
            int q_index = a_array.Length;
            BigInteger y = a_array[q_index - 1];
            //Console.WriteLine(y.ToBinaryString());
            for (int i = q_index - 2; i >= 0; i--) {
                y = y * x + a_array[i];
                y = (y & p) + (y >> FourUniHash.q);
                //Console.WriteLine(y.ToBinaryString());
            }
            
            //BigInteger x1 = 
                //a0 + a1 * x + a2 * BigInteger.Pow(x,2) + a3 * BigInteger.Pow(x,3);
            //g(x) = x1 mod p
            //BigInteger y = (x1 & p) + (x1 >> FourUniHash.q);
            if (y >= p) {
                y -= p;
            }
            //y = (y & 3);
            return y;
        }
    }
}