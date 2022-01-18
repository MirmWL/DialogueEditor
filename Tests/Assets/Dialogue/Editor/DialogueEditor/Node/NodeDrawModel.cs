using System;
using UnityEngine;

[Serializable]
public class NodeDrawModel
{
    public Texture2D MainTexture { get; private set; }

    private readonly Color _defaultBackGroundColor = Color.cyan;
    private readonly Color _selectedBackGroundColor = Color.yellow;

    public Rect NodeRect;
    private readonly Vector2Int _backGroundSize = new Vector2Int(130, 130);
    
    public NodeDrawModel(Vector2 _position)
    {
        NodeRect = new Rect(_position, _backGroundSize);
        InitTexture();
    }

    private Vector2 _center => new Vector2(NodeRect.size.x / 2, NodeRect.size.y / 2);
    
    public void InitTexture()
    {
        MainTexture = new Texture2D(1, 1);
        MainTexture.SetPixel(0, 0, _defaultBackGroundColor);
        MainTexture.Apply();
    }
    
    public void SetDefaultColor()
    {
        MainTexture.SetPixel(0, 0, _defaultBackGroundColor);
        MainTexture.Apply();
    }

    public void SetSelectedColor()
    {
        MainTexture.SetPixel(0, 0, _selectedBackGroundColor);
        MainTexture.Apply();
    }

    public void SetPosition(Vector2 _pos) => NodeRect.position = _pos - _center;
}
