namespace CustomDataSerialization;

public static class NodeInspector
{
    public static void HardInspectByNodesForward(ListNode head)
    {
        var curr = head;

        while (curr != null)
        {
            var currHash = curr.GetHashCode();
            var nodePrev = curr.Prev?.GetHashCode() ?? 0;
            var nodeNext = curr.Next?.GetHashCode() ?? 0;
            var nodeRand = curr.Rand?.GetHashCode() ?? 0;
            var nodeData = int.Parse(curr.Data);

            Console.WriteLine($"Node: #{currHash:00000000}, " +
                              $"\tPrev: #{nodePrev:00000000}, " +
                              $"\tNext: #{nodeNext:00000000}, " +
                              $"\tRand: #{nodeRand:00000000}, " +
                              $"\tData: ({nodeData:00000000})");

            curr = curr.Next;
        }
    }
}