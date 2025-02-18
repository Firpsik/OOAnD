using Hwdtech;
using Hwdtech.Ioc;
using Moq;

namespace SpaceBattle.Tests
{
    public class DependencyRegistrationExceptionTest
    {
        public DependencyRegistrationExceptionTest()
        {
            new InitScopeBasedIoCImplementationCommand().Execute();
            IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
        }

        [Fact]
        public void RegisterDependencies_ThrowsException_OnQueueAddFailure()
        {
            var commands = new Dictionary<string, IStrategy>()
            {
                {"StartRotate", new StartRotateStrategy()}
            };

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "command", (object[] args) => commands).Execute();

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "initDependecies", (object[] args) =>
                new InitGameDependenciesStrategy().Run(args)).Execute();

            var mockQueueAdd = new Mock<ICommand>();
            mockQueueAdd.Setup(m => m.Execute()).Throws(new Exception());

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Queue", (object[] args) =>
                mockQueueAdd.Object).Execute();

            var mockAdapter = new Mock<IRotateCommandStartable>();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "adapter", (object[] args) =>
                mockAdapter.Object).Execute();

            var id = Guid.NewGuid();
            var mockObj = new Mock<IUObject>();

            var registerDependencies = new RegisterDependencies(id);
            Assert.Throws<Exception>(() => registerDependencies.Execute());
        }
    }
}
