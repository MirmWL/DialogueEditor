using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class NodesDrawer : IDrawer
{
    public Action<Node> OnConnect;
    private readonly IReadOnlyList<Node> _nodes;

    public NodesDrawer(IReadOnlyList<Node> _nodes)
    {
        this._nodes = _nodes;

        Draw += DrawTextures;
        Draw += DrawFields;
    }

    public Action Draw { get; set; }

    private void DrawTextures()
    {
        foreach (Node _node in _nodes)
            GUI.DrawTexture(_node.DrawModel.NodeRect, _node.DrawModel.MainTexture);
    }

    private void DrawFields()
    {
        foreach (Node _node in _nodes)
        {
            GUILayout.BeginArea(_node.DrawModel.NodeRect);

            if(_node.State == NodeStateType.Selected)
                DrawCreateConnectionButton(_node);

            DrawNameLabel(_node);
            DrawPhraseLabel(_node);
            DrawTypeLabel(_node);
            DrawIndexLabel(_node);

            GUILayout.EndArea();
        }
    }
    
    private void DrawCreateConnectionButton(Node _node)
    {
        if (GUILayout.Button("Connect"))
            OnConnect.Invoke(_node); ;    
    }

    private void DrawIndexLabel(Node _node) => EditorGUILayout.LabelField($"index: {_node.Model.Index}");
    private void DrawNameLabel(Node _node) => EditorGUILayout.LabelField(_node.Model.Name);
    private void DrawPhraseLabel(Node _node) => EditorGUILayout.LabelField(_node.Model.Phrase);
    private void DrawTypeLabel(Node _node) => EditorGUILayout.LabelField($"type: {_node.Type}");
}
