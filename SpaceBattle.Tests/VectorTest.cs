using TechTalk.SpecFlow;

namespace SpaceBattle.Tests;

[Binding]
public class VectorTest
{
    private Vector? _vector1;
    private Vector? _vector2;
    private bool _ans;
    private int? _hashCode1;
    private int? _hashCode2;
    private object? _notVector;
    private Exception? _exception;

    [Given(@"объект не является вектором")]
    public void GivenObjectIsNotVector()
    {
        _notVector = new object();
    }

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
    public void GivenSecondVectorOneCoord(int p0)
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

    [When(@"происходит сравнение хэш-кодов")]
    public void WhenICalculateHashCodes()
    {
        if (_vector1 == null || _vector2 == null)
        {
            throw new ArgumentNullException("Векторы не могут быть null");
        }

        _hashCode1 = _vector1.GetHashCode();
        _hashCode2 = _vector2.GetHashCode();
    }

    [When(@"происходит сравнение вектора с объектом")]
    public void WhenICompareVectorWithObject()
    {
        if (_vector1 == null)
        {
            throw new ArgumentNullException("Векторы не могут быть null");
        }

        _ans = _vector1.Equals(_notVector);
    }

    [When(@"происходит сложение векторов")]
    public void WhenVectorsAreAdded()
    {
        try
        {
            if (_vector1 == null || _vector2 == null)
            {
                throw new ArgumentNullException("Векторы не могут быть null");
            }

            var result = _vector1 + _vector2;
        }
        catch (Exception ex)
        {
            _exception = ex;
        }
    }

    [Then(@"хэш-коды векторов равны")]
    public void ThenHashCodesAreEqual()
    {
        Assert.Equal(_hashCode1, _hashCode2);
    }

    [Then(@"хэш-коды векторов не равны")]
    public void ThenHashCodesAreNotEqual()
    {
        Assert.NotEqual(_hashCode1, _hashCode2);
    }

    [Then(@"получаем \((true|false)\)")]
    public void checkResult(bool expectedResult)
    {
        Assert.Equal(expectedResult, _ans);
    }

    [Then(@"возникает ошибка")]
    public void ThrowNullEx()
    {
        Assert.IsType<ArgumentNullException>(_exception);
    }

    [Then(@"получаем исключение")]
    public void ThrowEx()
    {
        Assert.NotNull(_exception);
        Assert.IsType<ArgumentException>(_exception);
    }

    [Then(@"результат равен false")]
    public void ThenResultIsFalse()
    {
        Assert.False(_ans);
    }
}
