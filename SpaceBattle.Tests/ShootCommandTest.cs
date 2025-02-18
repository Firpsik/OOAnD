using Hwdtech;
using Hwdtech.Ioc;
using Moq;

namespace SpaceBattle.Tests
{
    public class ShootCommandTest
    {
        public ShootCommandTest()
        {
            new InitScopeBasedIoCImplementationCommand().Execute();
            IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
        }

        [Fact]
        public void Shoot_Success()
        {
            var mockShootable = new Mock<IShootable>();
            mockShootable.SetupGet(m => m.Position);
            mockShootable.SetupGet(m => m.AmmoVelocity);

            var mockAmmo = new Mock<IUObject>();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "GetAmmo", (object[] args) => mockAmmo.Object).Execute();

            var mockStartRotate = new Mock<ICommand>();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "StartRotate", (object[] args) => mockStartRotate.Object).Execute();

            var shootCommand = new ShootCommand(mockShootable.Object);
            shootCommand.Execute();
            mockStartRotate.Verify(m => m.Execute(), Times.Once());
        }
        [Fact]
        public void Shoot_Fail()
        {
            var mockShootable = new Mock<IShootable>();
            mockShootable.SetupGet(m => m.Position).Throws(new Exception());
            mockShootable.SetupGet(m => m.AmmoVelocity);

            var mockAmmo = new Mock<IUObject>();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "GetAmmo", (object[] args) => mockAmmo.Object).Execute();

            var mockStartRotate = new Mock<ICommand>();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "StartRotate", (object[] args) =>
                mockStartRotate.Object).Execute();

            var shootCommand = new ShootCommand(mockShootable.Object);
            Assert.Throws<Exception>(() => shootCommand.Execute());
            mockStartRotate.Verify(m => m.Execute(), Times.Never);
        }
    }
}
