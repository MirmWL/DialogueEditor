using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class Node : IConnectable, ISavable
{
    public NodeModel Model;
    public NodeDrawModel DrawModel;
    
    public Node(NodeType _type, Vector2 _startPos, int _index)
    {
        Model = new NodeModel();
        DrawModel = new NodeDrawModel(_startPos);
        Model.Type = _type;
        Model.Index = _index;
    }

    public NodeType _Type { get => Model.Type; }
    public Rect Rect => DrawModel.NodeRect;
    public List<int> _ConnectTargetIndexes
    {
        get { return Model.ConnectTargetsIndexes; }
        set { Model.ConnectTargetsIndexes = value; }
    }

    public NodeStateType _State
    {
        get { return Model.State; }
        private set { Model.State = value; }
    }

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

        _State = _state;
    }

    void ISavable.Init()
    {
        DrawModel.InitTexture();
    }
}