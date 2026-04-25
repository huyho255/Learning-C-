using System;
using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int count = nums.Length;
        // Pre-allocating capacity avoids the cost of resizing the hash table
        var seen = new Dictionary<int, int>(count);

        for (int i = 0; i < count; i++) {
            int currentNum = nums[i];
            int complement = target - currentNum;

            // TryGetValue is a single-pass lookup (O(1))
            if (seen.TryGetValue(complement, out int index)) {
                return new int[] { index, i };
            }

            // Using the indexer here is safe because the problem 
            // guarantees only one solution exists.
            if (!seen.ContainsKey(currentNum)) {
                seen.Add(currentNum, i);
            }
        }

        return Array.Empty<int>();
    }
}