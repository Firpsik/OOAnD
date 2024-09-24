using Hwdtech;

namespace SpaceBattle;

public class BuildTreeCommand : ICommand
{
    private readonly string path;

    public BuildTreeCommand(string Path)
    {
        path = Path;
    }

    public void Execute()
    {
        var tree = new Dictionary<int, object>();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "BuildDecisionTree.Command", (object[] args) => tree).Execute();

        using (var reader = File.OpenText(path))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var nums = line.Split().Select(int.Parse).ToList();

                var node = IoC.Resolve<Dictionary<int, object>>("BuildDecisionTree.Command");

                nums.ForEach(num =>
                {
                    node.TryAdd(num, new Dictionary<int, object>());
                    node = (Dictionary<int, object>)node[num];
                });

            }
        }
    }
}
