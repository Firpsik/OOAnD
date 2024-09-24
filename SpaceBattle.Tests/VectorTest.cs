using TechTalk.SpecFlow;

namespace SpaceBattle.Tests;

[Binding]
public class VectorTest
{
    private Vector? _vector1;
    private Vector? _vector2;
    private bool _ans;
    private Exception? _exception;

    [Given(@"первый вектор равен \((.*), (.*)\)")]
    public void GivenFirstVec(int p0, int p1)
    {
        _vector1 = new Vector(new int[] { p0, p1 });
    }

    [Given(@"второй вектор равен \((.*), (.*)\)")]
    public void GivenSecondVector(int p0, int p1)
    {
        _vector2 = new Vector(new int[] { p0, p1 });
    }

    [Given(@"второй вектор равен \((.*)\)")]
    public void GivenSecondVector(int p0)
    {
        _vector2 = new Vector(new int[] { p0 });
    }

    [Given(@"второй вектор равен null")]
    public void GivenNullVector()
    {
        _vector2 = null;
    }

    [When(@"происходит сравнение векторов")]
    public void WhenVectorAction()
    {
        try
        {
            if (_vector1 == null || _vector2 == null)
            {
                throw new ArgumentNullException("Векторы не могут быть null");
            }

            _ans = _vector1.Equals(_vector2);
        }
        catch (Exception ex)
        {
            _exception = ex;
        }
    }

    [Then(@"получаем \((true|false)\)")]
    public void checkResult(bool expectedResult)
    {
        Assert.Equal(expectedResult, _ans);
    }

    [Then(@"возникает ошибка")]
    public void ThrowEx()
    {
        Assert.IsType<ArgumentNullException>(_exception);
    }
}
