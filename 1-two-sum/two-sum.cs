using System;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int n = nums.Length;
        // Tạo một mảng lưu index để không bị mất dấu sau khi sort
        int[] indices = new int[n];
        for (int i = 0; i < n; i++) indices[i] = i;

        // Sort mảng nums và mảng indices song song dựa trên giá trị của nums
        Array.Sort(nums, indices);

        int left = 0;
        int right = n - 1;

        while (left < right) {
            int sum = nums[left] + nums[right];

            if (sum == target) {
                return new int[] { indices[left], indices[right] };
            }
            else if (sum < target) {
                left++; // Cần tăng tổng lên
            }
            else {
                right--; // Cần giảm tổng xuống
            }
        }

        return new int[0];
    }
}