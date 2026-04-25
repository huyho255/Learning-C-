public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Key: the number, Value: its index
        Dictionary<int, int> seenNumbers = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++) {
            int complement = target - nums[i];

            // If the complement is in the dictionary, we found our pair
            if (seenNumbers.ContainsKey(complement)) {
                return new int[] { seenNumbers[complement], i };
            }

            // Otherwise, add the current number and its index to the dictionary
            // We use TryAdd or check ContainsKey to handle potential duplicate values 
            // (though the problem guarantees exactly one solution).
            if (!seenNumbers.ContainsKey(nums[i])) {
                seenNumbers.Add(nums[i], i);
            }
        }

        // Return an empty array if no solution is found (per constraints, this won't happen)
        return new int[0];
    }
}