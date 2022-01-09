using UnityEngine;
using System;
using UnityEditor;

public class SettingsPanelDrawer : IDrawer
{
    public Action<Node> OnDelete;

    private readonly SettingsPanelDrawModel _drawModel;
    private readonly SettingsPanelModel _settingsModel;

    public readonly SettingsDialogueToolsAreaDrawer DialogueToolsAreaDrawer;
    private readonly SettingsNodeAreaDrawer _nodeAreaDrawer;
    private readonly SettingsEventAreaDrawer _eventAreaDrawer;
    
    public SettingsPanelDrawer(SettingsPanelDrawModel _drawModel, SettingsPanelModel _settingsModel, SettingsEventHandler _eventHandler)
    {
        this._drawModel = _drawModel;
        this._settingsModel = _settingsModel;

        DialogueToolsAreaDrawer = new SettingsDialogueToolsAreaDrawer(_settingsModel, _drawModel);
        _nodeAreaDrawer = new SettingsNodeAreaDrawer(_settingsModel);
        _eventAreaDrawer = new SettingsEventAreaDrawer(_eventHandler);

        OnDelete += (s) => _eventHandler.ModelsController?.Remove(s.Model.Index);
        
        Draw += DrawTextures;
        Draw += DrawSettings;
    }

    public Action Draw { get; set; }

    private void DrawTextures()
    {
        GUI.DrawTexture(_drawModel.BackGroundRect, _drawModel.MainTexture);
    }

    private void DrawSettings()
    {
        GUILayout.BeginArea(_drawModel.BackGroundRect);

        if (_settingsModel.SelectedNode != null)
        {
            _nodeAreaDrawer.Draw.Invoke();
            _eventAreaDrawer.Draw.Invoke();
            
            EditorGUILayout.Space(20);
            DrawDeleteNodeButton();
        }
        
        DialogueToolsAreaDrawer.Draw.Invoke();
        GUILayout.EndArea();
    }
    
    private void DrawDeleteNodeButton()
    {
        if (GUILayout.Button("Delete node"))
        {         
            OnDelete.Invoke(_settingsModel.SelectedNode);
            _settingsModel.SetSelected(null);
        }
    }
}
