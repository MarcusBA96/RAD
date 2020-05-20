using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RAD_Project {
    public class MultiplyShiftHash {
        private UInt64 a = 0b1100110100001010000011100101111011110011001000000010010110100111;
        private int l;
        public MultiplyShiftHash(int l) {
            this.l = l;
        }
        public UInt64 HashValue(UInt64 x) {
            return ((a * x) >> (64 - l));
        }
    }
}