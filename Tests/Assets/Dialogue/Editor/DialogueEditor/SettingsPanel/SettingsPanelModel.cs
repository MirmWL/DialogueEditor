
public class SettingsPanelModel
{
    public string CurrentXmlPath;
    
    public Node SelectedNode { get; private set; }
    
    public void SetSelected(Node _node) => SelectedNode = _node;
}
