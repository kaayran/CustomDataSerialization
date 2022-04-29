namespace CustomDataSerialization;

public class NodeDeployer
{
    private readonly NodeConstructor _nodeConstructor;

    public NodeDeployer(NodeConstructor nodeConstructor)
    {
        _nodeConstructor = nodeConstructor;
    }

    private bool IsRandomNode(int lessThen, out int randIndex)
    {
        randIndex = -1;
        var rand = new Random();
        var isGood = Convert.ToBoolean(rand.Next(0, 2));

        if (!isGood) return false;

        randIndex = rand.Next(0, lessThen);
        Console.WriteLine($"Random index: {randIndex}");
        return true;
    }

    public void Deploy()
    {
        var nodes = _nodeConstructor.Nodes;
        var rands = _nodeConstructor.Randoms;

        for (var i = 0; i < nodes.Count; i++)
        {
            var node = nodes[i];

            if (i > 0) node.Prev = nodes[i - 1];
            if (i != nodes.Count - 1) node.Next = nodes[i + 1];

            if (!IsRandomNode(nodes.Count, out var randIndex) || rands <= 0) continue;

            node.Rand = nodes[randIndex];
            rands--;
        }

        Console.WriteLine("Nodes deployed.");
    }
}