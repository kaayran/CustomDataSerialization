namespace CustomDataSerialization;

public class NodeConstructor
{
    private readonly int _size;
    private readonly int _randoms;

    private int Size
    {
        get => _size;
        init => _size = value > 0 ? value : 10;
    }

    public int Randoms
    {
        get => _randoms;
        private init => _randoms = 0 <= value && value <= _size ? value : 0;
    }

    public List<ListNode> Nodes { get; }

    public NodeConstructor(int size, int randoms)
    {
        Size = size;
        Randoms = randoms;

        Nodes = new List<ListNode>(_size);
        CreateNodes();
    }

    private void CreateNodes()
    {
        for (var i = 0; i < _size; i++)
        {
            var node = new ListNode
            {
                Prev = null,
                Next = null,
                Rand = null,
                Data = "DATA"
            };

            Nodes.Add(node);
        }

        Console.WriteLine($"Nodes constructed. Size: {_size}, Rands: {_randoms}");
    }
}