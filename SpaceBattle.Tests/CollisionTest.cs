using Hwdtech;
using Hwdtech.Ioc;
using Dict = System.Collections.Generic.Dictionary<int, object>;

namespace SpaceBattle.Tests;

public class BuildTreeCommandTest
{
    public BuildTreeCommandTest()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();

        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
    }

    [Fact]
    public void BuildTreeCommandPositive()
    {
        var path = "../../../file.txt";
        new BuildTreeCommand(path).Execute();

        var tree = IoC.Resolve<Dict>("BuildDecisionTree.Command");

        Assert.NotNull(tree);

        Assert.True(tree.ContainsKey(1));
        var treeNext1 = (Dict)tree[1];

        Assert.True(treeNext1.ContainsKey(2));
        var treeNext2 = (Dict)treeNext1[2];

        Assert.True(treeNext2.ContainsKey(3));
        var treeNext3 = (Dict)treeNext2[3];

        Assert.True(treeNext3.ContainsKey(4));

        Assert.True(treeNext1.ContainsKey(5));
        var treeNext5 = (Dict)treeNext1[5];
        
        Assert.True(treeNext5.ContainsKey(6));
        var treeNext6 = (Dict)treeNext5[6];

        Assert.True(treeNext6.ContainsKey(7));
    }
}
