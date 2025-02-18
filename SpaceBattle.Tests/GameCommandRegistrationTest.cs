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
            var typeEndMove = "EndMove";
            var typeShoot = "Shoot";

            var commands = new Dictionary<string, IStrategy>(){
                {typeRotate, new RotateStrategy()},
                {typeStartRotate, new StartRotateStrategy()},
                {typeEndMove, new EndMoveStrategy()},
                {typeShoot, new ShootStrategy()},
            };

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "command", (object[] args) => commands).Execute();

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "initDependecies", (object[] args) =>
                new InitGameDependenciesStrategy().Run(args)).Execute();

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Queue", (object[] args) => args[1]).Execute();

            var mockAdapterRotable = new Mock<IRotable>();
            var mockAdapterRotateStartable = new Mock<IRotateCommandStartable>();
            var mockAdapterMoveEndable = new Mock<IMoveCommandEndable>();
            var mockAdapterShootable = new Mock<IShootable>();

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "adapter", (object[] args) =>
            {
                var adapterMap = new Dictionary<Type, object>
                {
                    { typeof(IRotable), mockAdapterRotable.Object },
                    { typeof(IRotateCommandStartable), mockAdapterRotateStartable.Object },
                    { typeof(IShootable), mockAdapterShootable.Object },
                    { typeof(IMoveCommandEndable), mockAdapterMoveEndable.Object },
                };

                var targetType = (Type)args[1];

                return adapterMap.GetValueOrDefault(targetType)
                    ?? throw new ArgumentException($"Adapter for type {targetType} is not registered.");
            }).Execute();

            var id = Guid.NewGuid();
            var mockObj = new Mock<IUObject>();
            var expTypeRotate = typeof(RotateCommand);
            var expTypeStartRotate = typeof(StartRotateCommand);
            var expTypeEndMove = typeof(EndMoveCommand);
            var expTypeShoot = typeof(ShootCommand);

            var registerDependencies = new RegisterDependencies(id);
            registerDependencies.Execute();

            Assert.Equal(expTypeRotate, IoC.Resolve<ICommand>("Rotate", mockObj.Object).GetType());
            Assert.Equal(expTypeStartRotate, IoC.Resolve<ICommand>("StartRotate", mockObj.Object).GetType());
            Assert.Equal(expTypeEndMove, IoC.Resolve<ICommand>("EndMove", mockObj.Object).GetType());
            Assert.Equal(expTypeShoot, IoC.Resolve<ICommand>("Shoot", mockObj.Object).GetType());
        }
    }
}

