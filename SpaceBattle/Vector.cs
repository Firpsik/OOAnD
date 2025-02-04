namespace SpaceBattle
{
    public class Vector
    {
        public int[] nums { get; set; }

        public Vector(int[] nums)
        {
            this.nums = nums;
        }

        public int Size()
        {
            return nums.Length;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            if (v1.Size() != v2.Size())
            {
                throw new ArgumentException();
            }
            else
            {
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
            var reduceValues = nums.Aggregate((sum, next) => HashCode.Combine(sum, next));
            return reduceValues;
        }
    }
}

