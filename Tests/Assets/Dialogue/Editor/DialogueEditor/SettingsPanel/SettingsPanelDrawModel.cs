using UnityEngine;

public class SettingsPanelDrawModel
{
    public Texture2D MainTexture = new Texture2D(1, 1);
    public readonly Color BackGroundColor = Color.gray;

    public readonly int CurrentDialogueLabelWidth = 120;

    public Rect BackGroundRect => new Rect(Screen.width - _backGroundWidth, 0, _backGroundWidth, _backGroundHeight);
    private readonly int _backGroundWidth = 300;
    private int _backGroundHeight => Screen.height;

    public Rect CreateNodeButtonRect => new Rect(BackGroundRect.x, BackGroundRect.yMax, _backGroundWidth, _backGroundHeight);
    public readonly int CreateNodeButtonHeight = 30;

    public readonly Rect NameEditFieldPos;
    public readonly Rect PhraseEditFieldPos;

    public SettingsPanelDrawModel()
    {
        MainTexture.SetPixel(0, 0, BackGroundColor);
        MainTexture.Apply();
    }
}
