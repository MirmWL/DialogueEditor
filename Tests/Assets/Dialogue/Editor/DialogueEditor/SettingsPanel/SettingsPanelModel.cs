using UnityEngine;

public class SettingsPanelModel
{
    public string CurrentXmlPath;
    public readonly string DialogueBaseDirectory = Application.streamingAssetsPath + "/DialogueBase"; 
    public Node SelectedNode { get; private set; }
    public void SetSelected(Node _node) => SelectedNode = _node;
}
