using UnityEditor;
using UnityEngine;

public class DialogueWindow : EditorWindow
{
    private CreateNodeArea _createPopup;
    private SettingsPanel _settingsPanel;
    private NodeController _nodeController;
    private ConnectionController _connectionController;
    private DialogueApplicator _applicator;
    private DrawController _drawController;

    [MenuItem("Window/Dialogue Editor")]
    public static void Open()
    {
        DialogueWindow _window = GetWindow<DialogueWindow>();
        _window.Show();
        _window.minSize = new Vector2(600, 300);
    }

    private void OnEnable()
    {
        _nodeController = new NodeController();
        _createPopup = new CreateNodeArea();
        _settingsPanel = new SettingsPanel();
        _connectionController = new ConnectionController();
        _applicator = new DialogueApplicator();

        _drawController = new DrawController(
            _nodeController.Drawer,
            _createPopup.Drawer,
            _settingsPanel.Drawer,
            _connectionController.Drawer
        );

        Subscribe();
    }

    private void Subscribe()
    {
        _nodeController.Drawer.OnConnect += _connectionController.SetOrigin;
        _nodeController.Selector.OnSelect += _connectionController.SetTarget;
        _nodeController.Selector.OnSelect += _settingsPanel.UpdatePanel;

        _createPopup.Drawer.OnCreate += _nodeController.Creator.Create;

        _settingsPanel.Drawer.DialogueToolsAreaDrawer.OnApply += _applicator.Apply;
        _settingsPanel.Drawer.OnDelete += _nodeController.Creator.Delete;
        _settingsPanel.Drawer.OnDelete += _connectionController.DeleteConnection;

        _applicator.RequireSortedNodes += _nodeController.GetSorted;
    }

    private void OnGUI()
    {
        _drawController.Draw();
        _nodeController.Selector.CheckClick();
    }
}