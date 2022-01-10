using UnityEngine;
using System.Collections.Generic;

public class Node : IConnectable
{
    public readonly NodeModel Model;
    public readonly NodeDrawModel DrawModel;
   
    public Node(NodeType _type, Vector2 _startPos, int _index)
    {
        Model = new NodeModel();
        DrawModel = new NodeDrawModel(_startPos);
        Type = _type;
        Model.Index = _index;
    }

    public NodeType Type { get; }
    public Rect Rect => DrawModel.NodeRect;
    public List<int> ConnectTargetsIndexes { get; set; } = new List<int>();
    public NodeStateType State { get; private set; }

    public void SetState(NodeStateType _state)
    {
        switch (_state)
        {
            case NodeStateType.Default:
                DrawModel.SetDefaultColor();
                break;
            case NodeStateType.Selected:
                DrawModel.SetSelectedColor();
                break;
        }

        State = _state;
    }
    
}