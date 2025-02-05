namespace SpaceBattle.Lib;

public class PositionGenerator
{
    private readonly int[] _countObject;
    public PositionGenerator(int[] countObject)
    {
        _countObject = countObject;
    }
    public IEnumerable<Vector> NextPosition()
    {
        for (var i = 0; i < _countObject.Length; i++)
        {
            for (var j = 0; j < _countObject[i]; j++)
            {
                yield return new Vector(new int[] { i, j });
            }
        }
    }
}
