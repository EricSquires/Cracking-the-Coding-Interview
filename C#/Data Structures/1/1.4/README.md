#Palindrome Permutation

Here we need to determine if a given string is a permutation of a palindrome.

###PalPermSort

My initial thought was to sort the string and check for more than one character having an odd number of occurrences. The algorithm uses the built-in Array.Sort and then just iterates through the results.

###PalPermBitVector

Since my intial solution is really just maintaining a count of all characters, my second pass at the problem uses a bit vector so I can run through the string in one pass to gather the counts. After the counting pass, I iterate over the counts and ensure at most one character has an odd count.

###Testing

Each solution is tested 100K times and runs on a randomly generated string between 20 and 50 characters in length. If a palindrome is required, we simply generate the first half, reverse it and tack it onto the end of the string.

#####Results

| Solution         | Permutation | Non-Permutation |
|------------------|-------------|-----------------|
| PalPermSort      | 0.00339 ms  | 0.00154 ms      |
| PalPermBitVector | 0.00023 ms  | 0.00021 ms      |

As expected, the bit vector solution is much faster.
