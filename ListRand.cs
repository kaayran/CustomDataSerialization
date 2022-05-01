using System.Text;

namespace CustomDataSerialization;

public class ListRand
{
    public ListNode Head;
    public ListNode Tail;
    public int Count;

    public void Serialize(FileStream s)
    {
        // Create Dictionary of ListNodes & Unique Id's (for Rand refs in future)
        var nodes = new Dictionary<ListNode, int>();
        // Walk-through in Nodes
        for (var (curr, index) = (Head, 0); curr != null; curr = curr.Next, index++)
        {
            nodes.Add(curr, index);
        }

        // Write only valuable data & refs to rand ListNodes
        using var writer = new BinaryWriter(s, Encoding.UTF8, false);
        for (var curr = Head; curr != null; curr = curr.Next)
        {
            // Add Data from current node 
            // And Id of Random Node that stored inside him
            writer.Write(curr.Data);
            writer.Write(curr.Rand != null ? nodes[curr.Rand] : -1);
            // We need to check, is Rand ListNode presented in Object
            // If not we set some kinda flag (-1) to check it on Deserialization
        }

        Console.WriteLine("Serialization of ListNodes complete.");
    }

    public void Deserialize(FileStream s)
    {
        // Re-create Dictionary to provide Data & ListNodes (Random)
        // To know, how to operate with indexes - we need a counter
        // Also, we need a list of Nodes to fast use of indexes
        var rawNodes = new Dictionary<int, (string data, int randIndex)>();
        var count = 0;
        using var reader = new BinaryReader(s, Encoding.UTF8, false);

        while (reader.PeekChar() != -1)
        {
            var data = reader.ReadString();
            var randIndex = reader.ReadInt32();

            rawNodes.Add(count++, (data, randIndex));
        }

        // Save local counter to ListRand.Count
        Count = count;
        var nodes = new List<ListNode>(Count);

        Head = new ListNode();
        for (var (curr, i) = (Head, 0); curr != null && i < Count; curr = curr.Next, i++)
        {
            nodes.Add(curr);
            curr.Data = rawNodes[i].data;
            // Check for Tail ListNode to assign Prev with Next
            if (i < Count - 1)
            {
                curr.Next = new ListNode
                {
                    Prev = curr
                };
            }
            else // Its last ListNode of sequence
            {
                Tail = curr;
            }

            // For ListNode.Rand we need to set default value (null)
            // Then we iterate through it and assign
        }

        for (var (curr, i) = (Head, 0); curr != null && i < Count; curr = curr.Next, i++)
        {
            curr.Rand = rawNodes[i].randIndex != -1 ? nodes[rawNodes[i].randIndex] : null;
            // Check for (-1) flag in data, then pass null to field
        }

        Console.WriteLine("Deserialization is finished.");
    }
}