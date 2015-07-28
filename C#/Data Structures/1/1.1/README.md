#Is Unique

The task here is to determine whether or not a given string is comprised of unique characters ("aba" = not unique, "abc" = unique).

###UniqueNaive

In my initial effort to just get started and make sure I got some solutions posted to encourage myself to continue, I simply worked up the naive solution. This solution is pretty awful, giving a O(N<sup>2</sup>) worst case run time. It could have been ever so slightly more naive, but the improvements aren't enough to affect its big-O runtime.

###UniqueSet

When I returned and actually tried to solve the problem appropriately, I relied on HashSet's O(1) insertion time to speed things up granting a O(N) worst case run time.

###Testing

In order to evaluate the performance of each implementation, I wrote up some performance testing code that runs each implementation 100,000 times on random strings of length 60. In cases where a unique string was required, I generate a unique string and set a random character to a random other character. These conditions ought to give me a reasonable idea of each implementation's average case runtime (when operating solely on totally random strings of the subset of characters I use, but I'm aiming to satisfy my intellectual curiosity, not publish a peer-reviewed paper).

#####Results

| Solution    | Unique String | Non-Unique String |
|-------------|---------------|-------------------|
| UniqueNaive | 0.01677 ms    | 0.00575 ms        |
| UniqueSet   | 0.00154 ms    | 0.00106 ms        |

As expected, the set implementation significantly outperforms the naive solution. Not much to say on that. Water is wet, sky is blue, sets are better than nested loops when you're evaluating uniqueness.
