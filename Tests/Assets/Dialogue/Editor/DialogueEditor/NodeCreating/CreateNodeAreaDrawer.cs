using System;
using UnityEditor;
using UnityEngine;

public class CreateNodeAreaDrawer : IDrawer
{
    public Action Draw { get; set; }
    public Action<NodeType> OnCreate;

    private readonly CreateNodeAreaDrawModel _drawModel;

    public CreateNodeAreaDrawer(CreateNodeAreaDrawModel _drawModel)
    {
        this._drawModel = _drawModel;

        Draw += DrawPopup;
    }

    private void DrawPopup()
    {     
        GUILayout.BeginArea(_drawModel.ZoneRect);

        EditorGUILayout.PrefixLabel("Create Node");

        DrawCreateButtons();
 
        GUILayout.EndArea();
    }
   
    private void DrawCreateButtons()
    {
        for (int i = 0; i < Enum.GetNames(typeof(NodeType)).Length; i++)
        {
            NodeType _current = (NodeType)Enum.GetValues(typeof(NodeType)).GetValue(i);

            if (GUILayout.Button(_current.ToString()))
                OnCreate.Invoke(_current); 
        }
    }
   
}
