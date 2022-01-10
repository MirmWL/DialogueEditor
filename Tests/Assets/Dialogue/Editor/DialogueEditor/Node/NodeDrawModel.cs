using UnityEngine;

public class NodeDrawModel
{
    public readonly Texture2D MainTexture = new Texture2D(1, 1);

    public readonly Color DefaultBackGroundColor = Color.cyan;
    public readonly Color SelectedBackGroundColor = Color.yellow;

    public Rect NodeRect;
    private readonly Vector2Int _backGroundSize = new Vector2Int(130, 130);
    
    public NodeDrawModel(Vector2 _position)
    {
        NodeRect = new Rect(_position, _backGroundSize);

        MainTexture.SetPixel(0, 0, DefaultBackGroundColor);
        MainTexture.Apply();
    }

    public void SetPosition(Vector2 _pos)
    {
        NodeRect.position = _pos - GetCenter();
    }

    public void SetDefaultColor()
    {
        MainTexture.SetPixel(0, 0, DefaultBackGroundColor);
        MainTexture.Apply();
    }

    public void SetSelectedColor()
    {
        MainTexture.SetPixel(0, 0, SelectedBackGroundColor);
        MainTexture.Apply();
    }

    private Vector2 GetCenter() => new Vector2(NodeRect.size.x / 2, NodeRect.size.y / 2);
}
