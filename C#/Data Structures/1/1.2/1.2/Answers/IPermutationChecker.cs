namespace _1._2
{
    public interface IPermutationChecker
    {
        /// <summary>
        /// Returns true if this string (<paramref name="s1"/>) is a permutation of the argument string (<paramref name="s2"/>)
        /// </summary>
        bool IsPermutation(string s1, string s2);
    }
}