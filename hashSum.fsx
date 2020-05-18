open Microsoft.FSharp.Core.Operators
open System.Diagnostics

let createStream ( n : int ) ( l : int ) : seq<uint64 * int> =
    seq {
        // We generate a random uint64 number .
        let rnd = System . Random ()
        let mutable a = 0UL
        let b : byte[] = Array . zeroCreate 8
        rnd.NextBytes ( b )
        let mutable x : uint64 = 0UL
        for i = 0 to 7 do
            a <- ( a <<< 8) + uint64 ( b .[ i ])
        // We demand that our random number has 30 zeros on the least
        // significant bits and then a one .
        a <- ( a ||| ((1UL <<< 31) - 1UL ) ) ^^^ ((1UL <<< 30)
            - 1UL )
        let mutable x = 0UL
        for i = 1 to ( n /3) do
            x <- x + a
            yield ( x &&& (((1UL <<< l ) - 1UL ) <<< 30) , 1)
        for i = 1 to (( n + 1) /3) do
            x <- x + a
            yield ( x &&& (((1UL <<< l ) - 1UL ) <<< 30) , -1)
        for i = 1 to ( n + 2) /3 do
            x <- x + a
            yield ( x &&& (((1UL <<< l ) - 1UL ) <<< 30) , 1)
    }

let multiplyModPrimeHash(x) =
    let q : int = 89
    let p : bigint = pown 2I q
    let a : bigint = 299396439594528984801708557I
    let b : bigint = 214229277696502365195904513I
    let l : int = 53
    let x1 : bigint = (a * x + b)
    let mutable y = (x1 &&& p) + (x1 >>> q)
    if (y > p) then y <- y-p else y <- y
    // printf "y : %A\n" y
    y % (pown 2I l)

let multiplyShiftHash(x)=
    let a : bigint = 1741209711818910523015I
    let l = 46
    ((a * x)>>>(64-l))


let n : int = 1000000
let l : int = 20

let S = createStream n l

let timer = new Stopwatch()

let mutable shift_sum = 0I
timer.Start()
for s in S do
    let s1 = bigint(fst s)
    shift_sum <- shift_sum + multiplyShiftHash s1
timer.Stop()
printf "Time Shift_Sum : %A \n" timer.Elapsed

printf "Shift_sum = %A\n" shift_sum

timer.Reset()
let mutable modprime_sum = 0I
timer.Start()
for s in S do
    let s2 = bigint(fst s)
    modprime_sum <- modprime_sum + multiplyModPrimeHash s2
timer.Stop()
printf "Time Modprime_sum : %A\n" timer.Elapsed

printf "Modprime_sum = %A\n" modprime_sum
