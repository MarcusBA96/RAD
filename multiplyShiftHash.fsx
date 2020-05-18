let multiplyShiftHash(x : bigint)=
    let a : bigint = 0b0100110110110110100010000001000101000100001001100101111100011011
    let l : bigint = 46
    return ((a * x)>>>(64-l))