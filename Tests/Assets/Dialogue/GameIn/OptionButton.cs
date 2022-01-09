using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
 
public class OptionButton : MonoBehaviour, IPointerClickHandler
{
    public Action<SettingNode> OnCicked;

    [SerializeField]
    private SettingNode _option;

    [SerializeField]
    private TextMeshProUGUI _text;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnCicked.Invoke(_option);
    }

    public void SetOption(SettingNode _node)
    {
        _text.text = _node.Phrase;
        _option = _node;
    }
}
