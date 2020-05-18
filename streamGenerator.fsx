let createStream ( n : int ) ( l : int ) : seq < uint64 * int > =
seq {
    // We generate a random uint64 number .
    let rnd = System . Random ()
    let mutable a = 0 UL
    let b : by te [] = Array . zeroCreate 8
    rnd . NextBytes ( b )
    let mutable x : uint64 = 0 UL
    for i = 0 to 7 do
        a <- ( a <<< 8) + uint64 ( b .[ i ])
    // We demand that our random number has 30 zeros on the least
    // significant bits and then a one .
    a <- ( a ||| ((1 UL <<< 31) - 1 UL ) ) ^^^ ((1 UL <<< 30)
        - 1 UL )
    let mutable x = 0 UL
    for i = 1 to ( n /3) do
        x <- x + a
        yield ( x &&& (((1 UL <<< l ) - 1 UL ) <<< 30) , 1)
    for i = 1 to (( n + 1) /3) do
        x <- x + a
        yield ( x &&& (((1 UL <<< l ) - 1 UL ) <<< 30) , -1)
    for i = 1 to ( n + 2) /3 do
        x <- x + a
        yield ( x &&& (((1 UL <<< l ) - 1 UL ) <<< 30) , 1)
}