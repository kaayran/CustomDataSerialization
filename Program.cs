namespace CustomDataSerialization;

public static class Program
{
    public static void Main(string[] args)
    {
        var cons = new NodeConstructor(10, 3);

        var inspector = new NodeInspector(cons);
        inspector.SoftInspect();

        var deployer = new NodeDeployer(cons);
        deployer.Deploy();

        inspector.HardInspect();

        Console.WriteLine($"Head: #{cons.Head.GetHashCode()}, Tail: #{cons.Tail.GetHashCode()}");

        InspectByNodesForward(cons.Head);
        InspectByNodesBackward(cons.Tail);
    }

    private static void InspectByNodesForward(ListNode head)
    {
        Console.WriteLine("Going forward");
        var curr = head;

        while (curr != null)
        {
            Console.WriteLine($"{curr.GetHashCode()}");
            curr = curr.Next;
        }
    }

    private static void InspectByNodesBackward(ListNode tail)
    {
        Console.WriteLine("Going backward");
        var curr = tail;

        while (curr != null)
        {
            Console.WriteLine($"{curr.GetHashCode()}");
            curr = curr.Prev;
        }
    }
}