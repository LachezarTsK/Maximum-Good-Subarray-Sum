
using System;
using System.Collections.Generic;

public class Solution
{
    private static readonly int NO_GOOD_SUBARRAYS = 0;

    public long MaximumSubarraySum(int[] input, int targetDifference)
    {
        Dictionary<int, long> valueToMinPrefixSum = new Dictionary<int, long>();

        long prefixSum = 0;
        long maxSubarraySum = long.MinValue;

        foreach (int value in input)
        {

            if (valueToMinPrefixSum.ContainsKey(value + targetDifference))
            {
                maxSubarraySum = Math.Max(maxSubarraySum, prefixSum + value - valueToMinPrefixSum[value + targetDifference]);
            }

            if (valueToMinPrefixSum.ContainsKey(value - targetDifference))
            {
                maxSubarraySum = Math.Max(maxSubarraySum, prefixSum + value - valueToMinPrefixSum[value - targetDifference]);
            }

            if (!valueToMinPrefixSum.ContainsKey(value))
            {
                valueToMinPrefixSum.Add(value, prefixSum);
            }
            else if (valueToMinPrefixSum[value] > prefixSum)
            {
                valueToMinPrefixSum[value] = prefixSum;
            }
            prefixSum += value;

        }
        return maxSubarraySum != long.MinValue ? maxSubarraySum : NO_GOOD_SUBARRAYS;
    }
}
