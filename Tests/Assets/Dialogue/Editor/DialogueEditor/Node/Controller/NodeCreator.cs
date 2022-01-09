using System.Collections.Generic;
using UnityEngine;
using System;

public class NodeCreator
{
    public Action<Node> OnCreate;
    private readonly List<Node> _nodes;
    private int _currentInitIndex = 0;

    public NodeCreator() { _nodes = new List<Node>(); } 

    public IReadOnlyList<Node> Nodes => _nodes;

    public void Create(NodeType _type)
    {
        Node _node = new Node(_type, new Vector2(0, 0), _currentInitIndex++);
   
        _nodes.Add(_node);
        OnCreate.Invoke(_node);
    }
   
    public void Delete(Node _node) => _nodes.Remove(_node);
}
