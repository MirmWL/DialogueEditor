using System;
using UnityEditor;
public class SettingsNodeAreaDrawer : IDrawer
{
    private readonly SettingsPanelModel _model;

    public SettingsNodeAreaDrawer(SettingsPanelModel _model)
    {
        this._model = _model;
        Draw += DrawNodeSettings;
    }
    
    public Action Draw { get; set; }

    private void DrawNodeSettings()
    {
        EditorGUILayout.LabelField("Node settings", EditorStyles.boldLabel);
        
        DrawNameField();
        DrawPhraseField();
    }
    
    private void DrawNameField()
    {
        _model.SelectedNode.Model.Name = EditorGUILayout.TextField(_model.SelectedNode.Model.Name);
    }

    private void DrawPhraseField()
    {
        _model.SelectedNode.Model.Phrase = EditorGUILayout.TextArea(_model.SelectedNode.Model.Phrase);
    }

}
