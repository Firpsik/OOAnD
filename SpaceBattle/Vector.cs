namespace SpaceBattle;

public class Vector
{
    public int[] nums { get; set; }

    public Vector(int[] nums)
    {
        this.nums = nums;
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        {
            if (v1 == null || v2 == null)
            {
                throw new ArgumentNullException("Оба вектора должны быть не null");
            }

            if (v1.nums.Length != v2.nums.Length)
            {
                throw new ArgumentException("вектор должен быть той же размерности");
            }

            return new Vector(v1.nums.Select((num, i) => num + v2.nums[i]).ToArray());
        }
    }
    public override bool Equals(object? obj)
    {
        if (obj is Vector vector)
        {
            return nums.SequenceEqual(vector.nums);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(nums);
    }
}

