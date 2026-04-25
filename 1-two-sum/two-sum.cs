using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Dictionary to store the number we've seen as the key, 
        // and its index as the value.
        Dictionary<int, int> seen = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++) {
            int complement = target - nums[i];
            
            // If we have already seen the complement, we found our pair.
            if (seen.ContainsKey(complement)) {
                return new int[] { seen[complement], i };
            }
            
            // Otherwise, add the current number and its index to the dictionary.
            // Using the indexer [] handles potential duplicate values safely 
            // by updating the index to the most recent one.
            seen[nums[i]] = i;
        }
        
        // The problem states there is exactly one valid solution, 
        // so we will always return inside the loop.
        return new int[0];
    }
}