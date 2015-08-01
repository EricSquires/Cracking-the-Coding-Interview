#URLify

This task entails replacing spaces with the URL equivalent "%20".

###URLRealWorld

I wrote this up just to have something to compare against. This solution just uses the built-in string.Replace function.

###URLSelfImplemented

This is the real solution asked for by the book. Run through the string starting from the front, replacing spaces along the way.

###Testing

Each method was run 100K times on a randomly generated string between 10 and 30 characters in length with between 0 and 5 spaces randomly distributed throughout.

#####Results

| Solution           |             |
|--------------------|-------------|
| URLRealWorld       | 0.00026 ms  |
| URLSelfImplemented | 0.00026 ms  |

The two methods appear not to differ in performance. This isn't all that surprising since there's no way to perform the task without running through the whole string.
