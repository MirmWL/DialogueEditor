using Dialogue.Editor.DialogueEditor.DataInteraction;

public class SaveController
{
    private readonly SaveBehaviour<Node> _nodeSaveBehaviour;
    private readonly Saver _saver;
    
    public SaveController(SaveNeeds _saveNeeds)
    {
        _saver = new Saver();
        _nodeSaveBehaviour = new NodeSaveBehaviour(_saver, _saveNeeds.Nodes);
    }

    public void Save() => _nodeSaveBehaviour.Save.Invoke();
}

