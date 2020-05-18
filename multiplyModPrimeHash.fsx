let multiplyModPrimeHash(x : bigint) =
    let q : bigint = 89
    let p : bigint = (pown 2 q) - 1
    let a : bigint = 0b01111011110100111101010011000001100011011101001101010100110101010110000111000101000001101
    let b : bigint = 0b01011000100110100110100000110101000010111111010100011111011011001000011001010011000000001
    let l : bigint = 53
    let x1 : bigint = a * x + b
    let y : bigint = (x1 &&& p) + (x >>> q)
    if (y >= p) then y-=p
    return y % (pown 2 l)