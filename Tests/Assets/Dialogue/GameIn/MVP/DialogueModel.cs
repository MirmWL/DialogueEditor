using System;
using UnityEngine;
using System.Linq;
using TreeEditor;

public class DialogueModel
{
    public Action<SettingNode> OnChangeNode;
    
    public DialogueSettings CurrentDialogue;
    
    private SettingNode _currentNode;
    private EventModelsController _currentEventController;
    
    public DialogueModel()
    {
        OnChangeNode += (s) =>
        {
            if (_currentNode != null)
                _currentEventController?.Execute(_currentNode.Index);

            _currentNode = s;
        };
    }
    
    private SettingNode _currentFirstConnect => GetCurrentFirstConnect();

    public void SetDialogue(TextAsset _asset, EventModelsController _eventModelsController)
    {
        CurrentDialogue = DialogueSettings.Load(_asset);
        _currentEventController = _eventModelsController;
        OnChangeNode(CurrentDialogue.Nodes[0]);
    }
    
    public void SkipNode()
    {
        if (GetSkipNodePossibility())
            OnChangeNode.Invoke(_currentFirstConnect);
        
        bool GetSkipNodePossibility() => _currentNode.Type == nameof(NodeType.Speech) && 
                                         _currentFirstConnect.Type == nameof(NodeType.Speech);
    }
    
    private SettingNode GetCurrentFirstConnect()
    {
        return CurrentDialogue.Nodes.FirstOrDefault(s => s.Index == _currentNode.Connect.ConnectIndexes[0]);
    }

    ~DialogueModel()
    {
        OnChangeNode = null;
        CurrentDialogue = null;
    }
}
