
#include <vector>
#include <climits>
#include <algorithm>
#include <unordered_map>
using namespace std;

class Solution {
    
    const static int NO_GOOD_SUBARRAYS = 0;
    
public:
    long long maximumSubarraySum(const vector<int>& input, int targetDifference) const {
        
        unordered_map<int, long long> valueToMinPrefixSum;

        long long prefixSum = 0;
        long long maxSubarraySum = numeric_limits<long long>::min();

        for (int value : input) {

            if (valueToMinPrefixSum.contains(value + targetDifference)) {
                maxSubarraySum = max(maxSubarraySum, prefixSum + value - valueToMinPrefixSum[value + targetDifference]);
            }
            if (valueToMinPrefixSum.contains(value - targetDifference)) {
                maxSubarraySum = max(maxSubarraySum, prefixSum + value - valueToMinPrefixSum[value - targetDifference]);
            }

            if (!valueToMinPrefixSum.contains(value) || valueToMinPrefixSum[value] > prefixSum) {
                valueToMinPrefixSum[value] = prefixSum;
            }
            prefixSum += value;
        }
        return maxSubarraySum != numeric_limits<long long>::min() ? maxSubarraySum : NO_GOOD_SUBARRAYS;
    }
};
