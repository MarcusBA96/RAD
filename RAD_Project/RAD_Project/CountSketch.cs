using System;
using System.Numerics;

namespace RAD_Project {
    public class CountSketch {
        private UInt64 m;
        private CountSketchHash hasher;
        private BigInteger[] C;

        public CountSketch(UInt64 _init_m) {
            m = _init_m;
            hasher = new CountSketchHash(m);
            C = new BigInteger[m];
        }

        public void Ci_Calculation(UInt64 x, int d) {
            UInt64 h_x = (UInt64)hasher.H(x);
            C[h_x] += hasher.S(x) * d;
        }

        public BigInteger Approximation() {
            BigInteger sum = 0;
            foreach (BigInteger c in C) {
                sum += c*c;
            }

            return sum;
        }
    }
}