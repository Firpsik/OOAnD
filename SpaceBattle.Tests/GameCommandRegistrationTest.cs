using Hwdtech;
using Hwdtech.Ioc;
using Moq;

namespace SpaceBattle.Tests
{
    public class GameCommandRegistrationTest
    {
        public GameCommandRegistrationTest()
        {
            new InitScopeBasedIoCImplementationCommand().Execute();
            IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
        }

        [Fact]
        public void RegisterDependencies_RegistersAllGameCommands_Successfully()
        {
            var typeRotate = "Rotate";
            var typeStartRotate = "StartRotate";

            var commands = new Dictionary<string, IStrategy>()
            {
                { typeRotate, new RotateStrategy() },
                { typeStartRotate, new StartRotateStrategy() }
            };

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "command", (object[] args) => commands).Execute();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "initDependencies", (object[] args) =>
                new InitGameDependenciesCommand()).Execute();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "QueueAdd", (object[] args) => args[1]).Execute();

            var mockAdapterRotable = new Mock<IRotable>();
            var mockAdapterRotateStartable = new Mock<IRotateCommandStartable>();

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "adapter", (object[] args) =>
            {
                var adapterMap = new Dictionary<Type, object>
                {
                    { typeof(IRotable), mockAdapterRotable.Object },
                    { typeof(IRotateCommandStartable), mockAdapterRotateStartable.Object },
                };

                var targetType = (Type)args[1];
                return adapterMap.GetValueOrDefault(targetType)
                    ?? throw new ArgumentException($"Adapter for type {targetType} is not registered.");
            }).Execute();

            var mockObj = new Mock<IUObject>();

            var initDependenciesCommand = IoC.Resolve<ICommand>("initDependencies");
            initDependenciesCommand.Execute();

            var rotateCommand = IoC.Resolve<ICommand>("Rotate", mockObj.Object);
            Assert.Equal(typeof(RotateCommand), rotateCommand.GetType());

            var startRotateCommand = IoC.Resolve<ICommand>("StartRotate", mockObj.Object);
            Assert.Equal(typeof(StartRotateCommand), startRotateCommand.GetType());
        }
    }
}
