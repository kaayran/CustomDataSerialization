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
        // For walk-through in Nodes
        for (var (curr, index) = (Head, 0); curr != null; curr = curr.Next, index++)
        {
            nodes.Add(curr, index);
        }

        // Write only valuable data & refs to rand ListNodes
        using var writer = new BinaryWriter(s, Encoding.UTF8, false);
        for (var curr = Head; curr != null; curr = curr.Next)
        {
            writer.Write(curr.Data);
            writer.Write(nodes[curr.Rand]);
            // Add Data from current node 
            // And Id of Random Node that stored inside him
        }

        Console.WriteLine("Serialization of ListNodes complete.");
    }

    public void Deserialize(FileStream s)
    {
        // Re-create Dictionary to provide Data & ListNodes (Random)
        // To know, how to operate with indexes - we need a counter
        var rawNodes = new Dictionary<int, (string, int)>();
        var selfIndex = 0; 
        using var reader = new BinaryReader(s, Encoding.UTF8, false);
        
        while (reader.PeekChar() != -1)
        {
            var data = reader.ReadString();
            var randIndex = reader.ReadInt32();
            
            rawNodes.Add(selfIndex++, (data, randIndex));
        }
    }
}