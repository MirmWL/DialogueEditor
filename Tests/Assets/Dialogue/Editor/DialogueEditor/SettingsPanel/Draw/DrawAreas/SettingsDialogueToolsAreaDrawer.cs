﻿using UnityEditor; 
using UnityEngine;
using System.IO;
using System;

public class SettingsDialogueToolsAreaDrawer : IDrawer
{
    public Action<string> OnApply;
    public Action OnSave;
    public Action<string> OnDialogueSet;
    
    private readonly SettingsPanelModel _model;
    private readonly SettingsPanelDrawModel _drawModel;

    public SettingsDialogueToolsAreaDrawer(SettingsPanelModel _model, SettingsPanelDrawModel _drawModel)
    {
        this._model = _model;
        this._drawModel = _drawModel;

        Draw += DrawDialogueTools;
    }

    public Action Draw { get; set; }
    
    private void DrawDialogueTools()
    {
        GUILayout.Space(10);
        EditorGUILayout.LabelField("Dialogue settings", EditorStyles.boldLabel);
        
        GUILayout.BeginHorizontal();
        
        DrawCurrentDialogueLabel();
        DrawChooseDialogueButton();

        if (string.IsNullOrEmpty(_model.CurrentXmlPath) == false)
            DrawApplyButton();
        
        GUILayout.EndHorizontal();
    }

    private void OpenDialogueFilePanel()
    {
        string _path = EditorUtility.OpenFilePanel(
            "Xml Files", 
            _model.DialogueBaseDirectory,
            "xml");
        
        OnDialogueSet.Invoke(_path);
        _model.CurrentXmlPath = _path;
    }

    private void DrawChooseDialogueButton()
    {
        if(GUILayout.Button("Choose Dialogue"))
            OpenDialogueFilePanel();
    }

    private void DrawCurrentDialogueLabel()
    {
        EditorGUILayout.LabelField(string.IsNullOrEmpty(_model.CurrentXmlPath) == false ? 
                Path.GetFileName(_model.CurrentXmlPath) :
                "no dialogue selected", 
            GUILayout.Width(_drawModel.CurrentDialogueLabelWidth));
    }

    private void DrawApplyButton()
    {
        if (GUILayout.Button("Apply"))
        {
            OnSave.Invoke();
            OnApply.Invoke(_model.CurrentXmlPath);
        }
    }

}