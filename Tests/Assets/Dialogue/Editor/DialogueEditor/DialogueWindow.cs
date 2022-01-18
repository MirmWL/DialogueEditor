using Dialogue.Editor.DialogueEditor.DataInteraction;
using UnityEditor;
using UnityEngine;

public class DialogueWindow : EditorWindow
{
    private CreateNodeArea _createArea;
    private SettingsPanel _settingsPanel;
    
    private NodeController _nodeController;
    private ConnectionController _connectionController;
    private DrawController _drawController;
    private SaveController _saveController;
    private LoadController _loadController;

    private DialogueApplicator _applicator;

    [MenuItem("Window/Dialogue Editor")]
    public static void Open()
    {
        DialogueWindow _window = GetWindow<DialogueWindow>();
        _window.Show();
        _window.minSize = new Vector2(600, 300);
    }

    private void OnEnable()
    {
        Create();
        Subscribe();
    }

    private void Create()
    {
        _nodeController = new NodeController();
        _createArea = new CreateNodeArea();
        _settingsPanel = new SettingsPanel();
        _connectionController = new ConnectionController();
        _applicator = new DialogueApplicator();
        
        _drawController = new DrawController(
            _nodeController.Drawer,
            _createArea.Drawer,
            _settingsPanel.Drawer,
            _connectionController.Drawer
        );

        SaveNeeds _saveNeeds = new SaveNeeds(
            _connectionController.Connections,
            _nodeController.Creator.Nodes,
            _nodeController.Creator);
        
        _saveController = new SaveController(_saveNeeds);
    
        LoadNeeds _loadNeeds = new LoadNeeds(_connectionController, _nodeController.Creator);
        _loadController = new LoadController(_loadNeeds);
    }
    
    private void Subscribe()
    {
        _nodeController.Drawer.OnConnect += _connectionController.SetOrigin;
        _nodeController.Selector.OnSelect += _connectionController.SetTarget;
        _nodeController.Selector.OnSelect += _settingsPanel.UpdatePanel;

        _createArea.Drawer.OnCreate += _nodeController.Creator.Create;

        _settingsPanel.Drawer.DialogueToolsAreaDrawer.OnSave += _saveController.Save;
        _settingsPanel.Drawer.DialogueToolsAreaDrawer.OnApply += _applicator.Apply;
        _settingsPanel.Drawer.OnDelete += _nodeController.Creator.Delete;
        _settingsPanel.Drawer.OnDelete += _connectionController.DeleteConnection;
        _settingsPanel.Drawer.DialogueToolsAreaDrawer.OnDialogueSet += _loadController.Load;
        
        _applicator.RequireSortedNodes += _nodeController.GetSortedCollection;
    }
    
    private void OnGUI()
    {
        _drawController.Draw();
        _nodeController.Selector.CheckClick();
    }
}