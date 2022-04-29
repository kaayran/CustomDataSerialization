namespace CustomDataSerialization;

public class NodeConstructor
{
    private readonly int _size;
    private readonly int _randoms;
    private List<ListNode> _nodes;

    private int Size
    {
        get => _size;
        init => _size = value > 0 ? value : 10;
    }

    private int Randoms
    {
        get => _randoms;
        init => _randoms = 0 <= value && value <= _size ? value : 0;
    }

    public List<ListNode> Nodes => _nodes;

    public NodeConstructor(int size, int randoms)
    {
        Size = size;
        Randoms = randoms;
        _nodes = new List<ListNode>();
    }

    private List<ListNode> CreateNodes()
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

            _nodes.Add(node);
        }

        return _nodes;
    }
}