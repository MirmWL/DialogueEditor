using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionDrawModel
{
    public readonly Color Color = Color.black;
    public readonly float Thickness = 5;
    private readonly KeyValuePair<IConnectable, IConnectable> _connection;

    public ConnectionDrawModel(KeyValuePair<IConnectable, IConnectable> _connection) { this._connection = _connection; }

    public Rect RectPosition => new Rect(_xPos, _yPos, 10, 10);

    private float _xPos => (_connection.Key.Rect.x + _connection.Value.Rect.x) / 2;
    private float _yPos => (_connection.Key.Rect.y + _connection.Value.Rect.y) / 2;
}
