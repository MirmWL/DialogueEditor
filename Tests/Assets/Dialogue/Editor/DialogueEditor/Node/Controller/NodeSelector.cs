using UnityEngine;
using System;
using System.Collections.Generic;

public class NodeSelector
{
    public Action<Node> OnSelect;
    public Action<Node> OnOpenInteractionPopup;

    private Node _selected;
    private readonly IReadOnlyList<Node> _nodes;

    public NodeSelector(IReadOnlyList<Node> _nodes)
    {
        this._nodes = _nodes;
        OnSelect += Select;
    }

    public void CheckClick()
    {
        if (CheckMouseClick())
        {
            foreach (Node _node in _nodes)
            {
                if (GetSelectPossibility(_node))
                    OnSelect.Invoke(_node);
                
            }

            Event.current.Use();
        }
    }

    private bool CheckMouseClick() => Event.current.isMouse;
    private bool GetSelectPossibility(Node _node) => _node.DrawModel.NodeRect.Contains(Event.current.mousePosition);


    private void Select(Node _node)
    {
        _selected?.SetState(NodeStateType.Default);

        _node.DrawModel.SetPosition(Event.current.mousePosition);
        _node.SetState(NodeStateType.Selected);

        Set(_node);
    }

    private void Set(Node _node) => _selected = _node;
}
