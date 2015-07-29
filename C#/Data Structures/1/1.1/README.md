#Is Unique

The task here is to determine whether or not a given string is comprised of unique characters ("aba" = not unique, "abc" = unique).

###UniqueNaive

In my initial effort to just get started and make sure I got some solutions posted to encourage myself to continue, I simply worked up the naive solution. This solution is pretty awful, giving a O(N<sup>2</sup>) worst case run time. It could have been ever so slightly more naive, but the improvements aren't enough to affect its big-O runtime.

###UniqueSet

When I returned and actually tried to solve the problem appropriately, I relied on HashSet's O(1) insertion time to speed things up granting a O(N) worst case run time.

###UniqueBitVector

I revisited this yet again, this time checking the hints in the book to see if I was missing anything. It suggested utilizing a bit vector which makes sense given the eary coonversion from characters to integers. I implemented a basic bit vector and reran the tests to rather disappointing effect as seen in the updated table below.

###Testing

In order to evaluate the performance of each implementation, I wrote up some performance testing code that runs each implementation 100,000 times on random strings of length 60. In cases where a unique string was required, I generate a unique string and set a random character to a random other character. These conditions ought to give me a reasonable idea of each implementation's average case runtime (when operating solely on totally random strings of the subset of characters I use, but I'm aiming to satisfy my intellectual curiosity, not publish a peer-reviewed paper).

#####Results

| Solution        | Unique String | Non-Unique String |
|-----------------|---------------|-------------------|
| UniqueNaive     | 0.01541 ms    | 0.00581 ms        |
| UniqueSet       | 0.00151 ms    | 0.00102 ms        |
| UniqueBitVector | 0.00297 ms    | 0.00187 ms        |

As expected, the set implementation significantly outperforms the naive solution. Not much to say on that. Water is wet, sky is blue, sets are better than nested loops when you're evaluating uniqueness.

**UniqueBitVector Update**

I would have expected the bit vector implementation to have a bit more parity with the set solution than is demonstated in testing. The bit vector operates as a set and while I expect that the .NET HashSet is far more optimized than my hand written BitVector class, I'm surprised to see such a desparity.

~~That being said, I should move on to other problems so I'm willing to chalk this up to "needs optimization" for now.~~

As soon as I committed that last sentence, I had a thought. I was testing in a debug build and with my project targeting Any CPU. First, lets see the results from switching to release mode:

| Solution        | Unique String | Non-Unique String |
|-----------------|---------------|-------------------|
| UniqueNaive     | 0.00251 ms    | 0.00119 ms        |
| UniqueSet       | 0.00104 ms    | 0.00074 ms        |
| UniqueBitVector | 0.00089 ms    | 0.00065 ms        |

Now I'm seeing the speed I expected from UniqueBitVector. It uses two 64-bit integers to support a 128 character range though, so let's make sure the program is built in 64-bit mode to ensure we're taking advantage of the processor architecture and see what happens:

| Solution        | Unique String | Non-Unique String |
|-----------------|---------------|-------------------|
| UniqueNaive     | 0.00296 ms    | 0.00125 ms        |
| UniqueSet       | 0.00089 ms    | 0.00063 ms        |
| UniqueBitVector | 0.00052 ms    | 0.00037 ms        |

And there we go. Any CPU targets 32-bit by default, so it was likely cramming those 64-bit ints into 32-bit ones, ruining the performance of my BitVector class.
