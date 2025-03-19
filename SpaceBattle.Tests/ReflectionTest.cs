using Hwdtech;
using Hwdtech.Ioc;
using Moq;

namespace SpaceBattle.Tests
{
    internal class Service
    {
        public IRotable rotable;
        public ICommand command;
        public IRotateCommandStartable rotateStartable;

        public Service(ICommand Command, IRotable Rotable, IRotateCommandStartable RotateStartable)
        {
            command = Command;
            rotable = Rotable;
            rotateStartable = RotateStartable;
        }
    }

    public class DependencyInjectionFeature
    {
        public DependencyInjectionFeature()
        {
            new InitScopeBasedIoCImplementationCommand().Execute();
            IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
        }

        [Fact]
        public void DependenciesShouldResolveCorrectly()
        {
            var commandMock = new Mock<ICommand>().Object;
            var rotableMock = new Mock<IRotable>().Object;
            var rotateStartableMock = new Mock<IRotateCommandStartable>().Object;

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", $"{typeof(ICommand)}", (object[] args) => { return commandMock; }).Execute();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", $"{typeof(IRotable)}", (object[] args) => { return rotableMock; }).Execute();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", $"{typeof(IRotateCommandStartable)}", (object[] args) => { return rotateStartableMock; }).Execute();

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "GetInstance",
            (object[] args) =>
            {
                var type = (Type)args[0];
                return DependencyInjection.GetInstance(type);
            }).Execute();

            var instance = IoC.Resolve<Service>("GetInstance", typeof(Service));

            Assert.NotNull(instance);
            Assert.Same(commandMock, instance.command);
            Assert.Same(rotableMock, instance.rotable);
            Assert.Same(rotateStartableMock, instance.rotateStartable);
        }
    }
}
