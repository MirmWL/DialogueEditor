using System;
using UnityEngine;

public interface IDialogueView
{
    Action<TextAsset, EventModelsController> Open { get; set; }
    Action OnClick { get; set; }
    Action<SettingNode> OnOptionClick { get; set; }

    string NameText { get; set; }
    string PhraseText { get; set; }

    void UpdateOptionsState(SettingNode[] _connectTatgets);
}
