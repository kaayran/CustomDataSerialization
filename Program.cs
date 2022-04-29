namespace CustomDataSerialization;

public static class Program
{
    public static void Main(string[] args)
    {
        var cons = new NodeConstructor(10, 10);
        var deployer = new NodeDeployer(cons);
        deployer.Deploy();

        Console.WriteLine($"Head: #{cons.Head.GetHashCode()}, Tail: #{cons.Tail.GetHashCode()}");

        // Real workflow from here
        var listRand = new ListRand
        {
            Head = cons.Head,
            Tail = cons.Tail,
            Count = cons.Size
        };

        const string path = @"A:\Repositories\C#\CustomDataSerialization\Data\data.txt";
        var fsWrite = new FileStream(path, FileMode.Create);
        listRand.Serialize(fsWrite);
        NodeInspector.HardInspectByNodesForward(listRand.Head);

        var fsRead = new FileStream(path, FileMode.Open);
        listRand.Deserialize(fsRead);
        NodeInspector.HardInspectByNodesForward(listRand.Head);
    }
}