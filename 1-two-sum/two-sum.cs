public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Tăng size lên 2^15 (32768) để load factor cực thấp cho 10^4 phần tử
        const int size = 32768; 
        const int mask = size - 1;
        
        int[] keys = new int[size];
        int[] values = new int[size];
        // Dùng byte thay cho bool để tiết kiệm bộ nhớ hoặc giữ nguyên bool
        bool[] occupied = new bool[size];

        for (int i = 0; i < nums.Length; i++) {
            int num = nums[i];
            int complement = target - num;

            // Hàm băm đơn giản nhưng hiệu quả cho số nguyên (kể cả số âm)
            int hComp = GetHash(complement, mask);
            while (occupied[hComp]) {
                if (keys[hComp] == complement) {
                    return new int[] { values[hComp], i };
                }
                hComp = (hComp + 1) & mask;
            }

            int hNum = GetHash(num, mask);
            while (occupied[hNum]) {
                if (keys[hNum] == num) break; 
                hNum = (hNum + 1) & mask;
            }
            keys[hNum] = num;
            values[hNum] = i;
            occupied[hNum] = true;
        }

        return null;
    }

    // Hàm lấy index băm xử lý cả số âm bằng bitwise
    private int GetHash(int key, int mask) {
        // Phép XOR dịch bit giúp phân tán các bit tốt hơn, giảm xung đột
        uint h = (uint)key;
        return (int)((h ^ (h >> 16)) & (uint)mask);
    }
}