#One Away

In this problem, we must determine whether or not two strings are a single edit apart from being equal.

###OneAwaySimple

This was the first solution that came to mind. First, do some trivial tests to filter out simple cases like equal strings or strings whose lengths differ by more than 1. The meat of the algorithm resides in the following two loops:

    for (; idxBegin < minStr.Length && minStr[idxBegin] == maxStr[idxBegin]; idxBegin++) ;
    for (; maxStr.Length - idxEnd > idxBegin && minStr[minStr.Length - idxEnd] == maxStr[maxStr.Length - idxEnd]; idxEnd++) ;
    
In the first loop, we start from the beginning of the strings and iterate until we find a difference. The second loop performs the same check starting from the end of each string. The return value, `idxBegin == maxStr.Length - idxEnd`, checks to see if we came up with the same index from the beginning and end. The indices will only be the same if there's no more than a single edit in the string.
