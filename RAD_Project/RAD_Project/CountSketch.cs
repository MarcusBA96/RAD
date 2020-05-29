using System;
using System.Numerics;

namespace RAD_Project {
    public class CountSketch {
        private BigInteger m;
        private CountSketchHash hasher;
        private BigInteger[] C;

        public CountSketch(BigInteger _init_m) {
            m = _init_m;
            hasher = new CountSketchHash(m);
            ulong m_int = (ulong) _init_m;
            C = new BigInteger[m_int];
            //Console.WriteLine(C.Length);

        }
        
        public void Ci_Calculation(UInt64 x, int d) {
            BigInteger h_x = hasher.H(x);
            C[(UInt64) h_x] += hasher.S(x) * d;
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