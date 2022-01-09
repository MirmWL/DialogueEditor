using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private TextAsset _asset;

    [SerializeField]
    private DialoguePanelView _panel;
    
    [SerializeField]
    private EventModelsController _eventController;
    
    private void Start() => _panel.Open.Invoke(_asset, _eventController);
}
