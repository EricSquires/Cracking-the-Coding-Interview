#Is Permutation

The task is to determine whether or not two given strings are permutations of one another. A string is a permutation of another string if it contains the same characters in the same quantity.

###PermutationNaive

My first attempt at the problem. Relying on the easy conversion from char to int, the class simply runs through each string, maintaining an int array of character counts where the index is the character's integer value. The class then runs through the resulting arrays and checks the counts.

###PermutationSort

The book hinted that there was an O(N·log(N)) solution that didn't require the space of my initial solution. Sorting winds up being around that complexity for Quicksort and it doesn't take up much, if any, space so I decided to incorporate sorting into a solution. The class just sorts each string and then compares them for equality.

###Testing

My testing methodology is essentially unchanged from my previous tests. Each algorithm is executed once to trigger initial overhead, then run and timed 100K times with random inputs. Inputs that were meant to be permutations were created by generating a random string, then shuffling it for the second input. Non-permutation inputs were simply randomly generated with the same lenght and checked to ensure they weren't permutations before being tested.

#####Results

| Solution         | Permutation | Non-Permutation |
|------------------|-------------|-----------------|
| PermutationNaive | 0.00026 ms  | 0.00021 ms      |
| PermutationSort  | 0.00234 ms  | 0.00230 ms      |

Results are pretty in line with what I'd expect although the gap is much wider than I would have thought. PermutationNaive, despite its name, is quite a bit faster since its simply iterating through each string once and then once through the resulting arrays doing integer incrementation or comparison along the way. PermutationSort on the other hand, must sort each string which puts its runtime at O(N·log(N)) on average according to the [MSDN documentation](https://msdn.microsoft.com/en-us/library/kwx6zbd4.aspx).
