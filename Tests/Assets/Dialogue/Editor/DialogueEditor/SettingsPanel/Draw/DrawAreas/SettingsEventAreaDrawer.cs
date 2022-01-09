using UnityEditor;
using System;

public class SettingsEventAreaDrawer : IDrawer
{
    private readonly SettingsEventHandler _eventHandler;
    
    public SettingsEventAreaDrawer(SettingsEventHandler _eventHandler)
    {
        this._eventHandler = _eventHandler;
        Draw += DrawEventArea;
    }
    
    public Action Draw { get; set; }

    private void DrawEventArea()
    {
        EditorGUILayout.Space(20);

        EditorGUILayout.LabelField("Event", EditorStyles.boldLabel);
        DrawEventBaseField();
        DrawEventProperty();
        
        EditorGUILayout.Space(20);
    }
    
    private void DrawEventBaseField()
    { 
        EventModelsController _eventModelsController = (EventModelsController)EditorGUILayout.ObjectField(_eventHandler.ModelsController, typeof(EventModelsController));
        
        if (_eventModelsController != _eventHandler.ModelsController)
            _eventHandler.SetController(_eventModelsController);
    }

    private void DrawEventProperty()
    {
        if (_eventHandler.ModelsController != null)
        {
            _eventHandler.SetupSerializedObject();
            _eventHandler.SetupSerializedProperties();
            EditorGUILayout.Space(10);
            EditorGUILayout.PropertyField(_eventHandler.ModelProperty, true);
            _eventHandler.ApplyModifiedProperty();
        }
    }
}
