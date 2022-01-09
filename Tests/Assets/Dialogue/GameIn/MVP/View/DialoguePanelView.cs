using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Linq;
using System;

public class DialoguePanelView : MonoBehaviour, IPointerClickHandler, IDialogueView
{ 
    [SerializeField]
    private OptionButton[] _optionButtons;

    [SerializeField]
    private TextMeshProUGUI _nameText;

    [SerializeField]
    private TextMeshProUGUI _phraseText;

    public Action<TextAsset, EventModelsController> Open { get; set; }
    public Action OnClick { get; set; }
    public Action<SettingNode> OnOptionClick { get; set; }

    public string NameText 
    {
        get { return NameText; }
        set { _nameText.text = value; }
    }

    public string PhraseText
    {
        get { return PhraseText; }
        set { _phraseText.text = value; }     
    }

    private void Awake()
    {
        new DialoguePresenter(this);
        _optionButtons.ToList().ForEach(s => s.OnCicked = (_node) => OnOptionClick(_node));
    }

    public void OnPointerClick(PointerEventData eventData) => OnClick.Invoke();

    public void UpdateOptionsState(SettingNode[] _connectTatgets)
    {
        _optionButtons.ToList().ForEach(s => s.gameObject.SetActive(false));

        for (int i = 0; i < _optionButtons.Length && i < _connectTatgets.Length; i++)
        {
            if (_connectTatgets[i].Type == nameof(NodeType.Option))
            {
                _optionButtons[i].SetOption(_connectTatgets[i]);
                _optionButtons[i].gameObject.SetActive(true);
            }
        }
    }
    
    private void OnDestroy()
    {
        Open = null;
        OnClick = null;
        OnOptionClick = null;
    }
}
