using Hwdtech;
using Hwdtech.Ioc;

namespace SpaceBattle.Tests;

public class TestAdapterBulider
{
    public TestAdapterBulider()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
    }

    [Fact]
    public void SuccessfullTest()
    {

        var objType = typeof(IUObject);
        var adapterInterface = typeof(IRotable);

        var result = new Adapter(objType, adapterInterface).Build();

        var expected = @"public class IRotableAdapter : IRotable {
        IUObject _obj;
    
        public IRotableAdapter(IUObject obj) => _obj = obj;
    
        public Angle Direction
        {
        
            get
            {
                return IoC.Resolve<Angle>(""Get.Property"", ""Direction"", _obj);
            }
        
            set
            {
                return IoC.Resolve<ICommand>(""Set.Property"", ""Direction"", _obj, value).Execute();
            }
        }
        
        public Angle AngularVelocity
        {
        
            get
            {
                return IoC.Resolve<Angle>(""Get.Property"", ""AngularVelocity"", _obj);
            }
        
        }
        
    }";

        Assert.Equal(expected, result);
    }
}
