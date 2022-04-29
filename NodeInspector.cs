﻿namespace CustomDataSerialization;

public class NodeInspector
{
    private readonly NodeConstructor _nodeConstructor;

    public NodeInspector()
    {
    }

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
            var nodePrev = node.Prev?.GetHashCode() ?? 0;
            var nodeNext = node.Next?.GetHashCode() ?? 0;
            var nodeRand = node.Rand?.GetHashCode() ?? 0;
            var nodeData = node.Data;

            Console.WriteLine($"Node: #{node.GetHashCode()}, " +
                              $"Prev: #{nodePrev}, " +
                              $"Next: #{nodeNext}, " +
                              $"Rand: #{nodeRand}, " +
                              $"Data ({nodeData})");
        }

        Console.WriteLine("Hard inspection finished.");
    }

    public static void InspectByNodesForward(ListNode head)
    {
        Console.WriteLine("Going forward");
        var curr = head;

        while (curr != null)
        {
            Console.WriteLine($"{curr.GetHashCode()}");
            curr = curr.Next;
        }
    }

    public static void InspectByNodesBackward(ListNode tail)
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