
/**
 * @param {number[]} input
 * @param {number} targetDifference
 * @return {number}
 */
var maximumSubarraySum = function (input, targetDifference) {
    const NO_GOOD_SUBARRAYS = 0;
    const valueToMinPrefixSum = new Map();

    let prefixSum = 0;
    let maxSubarraySum = Number.MIN_SAFE_INTEGER;

    for (let value of input) {

        if (valueToMinPrefixSum.has(value + targetDifference)) {
            maxSubarraySum = Math.max(maxSubarraySum, prefixSum + value - valueToMinPrefixSum.get(value + targetDifference));
        }
        if (valueToMinPrefixSum.has(value - targetDifference)) {
            maxSubarraySum = Math.max(maxSubarraySum, prefixSum + value - valueToMinPrefixSum.get(value - targetDifference));
        }

        if (!valueToMinPrefixSum.has(value) || valueToMinPrefixSum.get(value) > prefixSum) {
            valueToMinPrefixSum.set(value, prefixSum);
        }
        prefixSum += value;
    }
    return maxSubarraySum !== Number.MIN_SAFE_INTEGER ? maxSubarraySum : NO_GOOD_SUBARRAYS;
};
