namespace CustomDataSerialization;

public static class NodeInspector
{
    public static void HardInspectByNodesForward(ListNode head)
    {
        Console.WriteLine("Going forward");
        var curr = head;

        while (curr != null)
        {
            var nodePrev = curr.Prev?.GetHashCode() ?? 0;
            var nodeNext = curr.Next?.GetHashCode() ?? 0;
            var nodeRand = curr.Rand?.GetHashCode() ?? 0;
            var nodeData = curr.Data;

            Console.WriteLine($"Node: #{curr.GetHashCode()}, " +
                              $"Prev: #{nodePrev}, " +
                              $"Next: #{nodeNext}, " +
                              $"Rand: #{nodeRand}, " +
                              $"Data ({nodeData})");

            curr = curr.Next;
        }
    }
}