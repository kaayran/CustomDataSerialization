namespace CustomDataSerialization;

public class NodeDeployer
{
    private readonly NodeConstructor _nodeConstructor;

    public NodeDeployer(NodeConstructor nodeConstructor)
    {
        _nodeConstructor = nodeConstructor;
    }

    private int RandomIndex(int lessThen)
    {
        var rand = new Random();
        var randValue = rand.Next(0, lessThen);
        Console.WriteLine($"RandomIndex: {randValue}");

        return randValue;
    }

    public void Deploy()
    {
        var nodes = _nodeConstructor.Nodes;
        var rands = _nodeConstructor.Randoms;

        for (var i = 0; i < nodes.Count - 1; i++)
        {
            var node = nodes[i];
            node.Next = nodes[i + 1];
            node.Prev = nodes[i - 1];

            if (rands <= 0) continue;
            node.Rand = nodes[RandomIndex(nodes.Count)];
            rands--;
        }

        Console.WriteLine("Nodes deployed.");
    }
}