using Hwdtech;

namespace SpaceBattle;

public static class DependencyInjection
{
    public static object GetInstance(Type type)
    {
        _ = type ?? throw new ArgumentNullException(nameof(type));

        var constructor = type.GetConstructors().FirstOrDefault()
            ?? throw new InvalidOperationException($"No public constructors found for type: {type}");

        var parameters = constructor.GetParameters()
            .Select(p => IoC.Resolve<object>($"{p.ParameterType}")).ToArray();

        return constructor.Invoke(parameters);
    }
}
