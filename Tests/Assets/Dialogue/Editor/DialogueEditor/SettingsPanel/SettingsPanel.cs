
public class SettingsPanel
{
    public readonly SettingsPanelDrawer Drawer;
    private readonly SettingsPanelDrawModel _drawModel;
    private readonly SettingsPanelModel _model;
    private readonly SettingsEventHandler _eventHandler;
    
    public SettingsPanel()
    {
        _drawModel = new SettingsPanelDrawModel();
        _model = new SettingsPanelModel();
        _eventHandler = new SettingsEventHandler(_model);
        Drawer = new SettingsPanelDrawer(_drawModel, _model, _eventHandler);
    }

    public void UpdatePanel(Node _node) => _model.SetSelected(_node);
}
