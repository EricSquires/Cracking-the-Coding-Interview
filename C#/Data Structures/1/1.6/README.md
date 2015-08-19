#String Compression

This task asks us to implement a simple [Run-length Encoding](https://en.wikipedia.org/wiki/Run-length_encoding) algorithm.

###CompressorSimple

The task is a simple one so there's not a lot to say. Simply run through the string incrementing a counter. Every time a different character is encountered, print out the previous character along with its count and reset the counter.

**Note:** The book asks for an implementation that will write out a number even for characters that appear only once in a row. I've ignored this requirement since it needlessly doubles the size of single characters.
