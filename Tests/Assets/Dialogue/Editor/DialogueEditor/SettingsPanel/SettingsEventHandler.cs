using System.Linq;
using System.Threading;
using UnityEditor;

public class SettingsEventHandler
{
    private SerializedObject _controllerObject;
    private SerializedProperty _modelsProperty;

    private readonly SettingsPanelModel _settingsModel;
    
    public SettingsEventHandler(SettingsPanelModel _settingsModel) { this._settingsModel = _settingsModel; }

    public EventModelsController ModelsController { get; private set; }
    public SerializedProperty ModelProperty { get; private set; }
    private EventModel _selectedModel =>  GetModelByNodeIndex(_selectedNode.Model.Index);
    private Node _selectedNode => _settingsModel.SelectedNode;
    
    public void SetController(EventModelsController _modelsController)
    {
        ModelsController = _modelsController;
        ModelsController?.Init();
        
        SetupSerializedObject();
    }

    public void SetupSerializedObject() => _controllerObject = new SerializedObject(ModelsController);

    public void SetupSerializedProperties()
    {
        _modelsProperty = _controllerObject
            .FindProperty(nameof(ModelsController.EventModels));

        if (_selectedModel != null)
        {
            SerializedProperty _modelProperty = _modelsProperty
                .GetArrayElementAtIndex(ModelsController.EventModels.FindIndex(s => s == _selectedModel));

            ModelProperty = _modelProperty;
        }

        else
            ModelsController.Add(_selectedNode.Model.Index);
    }

    private EventModel GetModelByNodeIndex(int _matchIndex)
    {
        return ModelsController.EventModels
            .FirstOrDefault(s => s.NodeIndex == _matchIndex);
    }

    public void ApplyModifiedProperty() => _controllerObject.ApplyModifiedProperties();

}
