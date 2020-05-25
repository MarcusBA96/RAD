using System;
using System.Numerics;

namespace RAD_Project {
    public class CountSketchHash {
        private UInt64 m;
        private FourUniHash hasher = new FourUniHash();
        private static int b = 89;

        public CountSketchHash(UInt64 _init_m) {
            m = _init_m;
        }
        public BigInteger H(BigInteger x) {
             BigInteger g = hasher.HashValue(x);
             return g & (m-1);
        }

        public BigInteger S(BigInteger x) {
            BigInteger g = hasher.HashValue(x);
            BigInteger bx = (g >> (CountSketchHash.b - 1));
            Console.WriteLine("Four Uni Hash: {0}, B(x): {1}", g, bx);
            return 1 - 2 * bx;
        }
    }
}

