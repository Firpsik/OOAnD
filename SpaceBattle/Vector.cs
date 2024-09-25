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
        return new Vector(v1.nums.Select((num, i) => num + v2.nums[i]).ToArray());
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

