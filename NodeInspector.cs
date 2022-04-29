﻿namespace CustomDataSerialization;

public class NodeInspector
{
    private readonly NodeConstructor _nodeConstructor;

    public NodeInspector(NodeConstructor nodeConstructor)
    {
        _nodeConstructor = nodeConstructor;
    }

    public void SoftInspect()
    {
        var nodes = _nodeConstructor.Nodes;

        foreach (var node in nodes)
        {
            Console.WriteLine($"Node #{node.GetHashCode()}, DATA: {node.Data}");
        }

        Console.WriteLine("Soft inspection finished.");
    }

    public void HardInspect()
    {
        var nodes = _nodeConstructor.Nodes;

        foreach (var node in nodes)
        {
            var nodePrev = node.Prev.GetHashCode();
            var nodeNext = node.Next.GetHashCode();
            var nodeRand = node.Prev.GetHashCode();
            var nodeData = node.Data;

            Console.WriteLine($"Node: #{node.GetHashCode()}, " +
                              $"Prev: #{nodePrev}, " +
                              $"Next: #{nodeNext}, " +
                              $"Rand: #{nodeRand}, " +
                              $"Data ({nodeData})");
        }

        Console.WriteLine("Hard inspection finished.");
    }
}