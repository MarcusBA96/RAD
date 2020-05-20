using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RAD_Project {
    public class MultiplyShiftHash {
        private UInt64 a = 0b1100110100001010000011100101111011110011001000000010010110100111;
        private int l;
        private UInt64 key;
        public MultiplyShiftHash(int l, UInt64 x) {
            this.key = x;
            this.l = l;
        }
        public UInt64 HashValue() {
            return ((a * key) >> (64 - l));
        }
    }
}