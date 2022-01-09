using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ConnectionsDrawer : IDrawer
{
    private readonly IReadOnlyList<Connection> _connections;

    public ConnectionsDrawer(IReadOnlyList<Connection> _connections) 
    { 
        this._connections = _connections;

        Draw += DrawLine;
    }

    public Action Draw { get; set; }

    private void DrawLine()
    {
        foreach (Connection _connection in _connections)
        {
            Vector2 _origin = _connection.ConnectionPair.Key.Rect.position;
            Vector2 _target = _connection.ConnectionPair.Value.Rect.position;

            Handles.DrawLine(_origin, _target);
        }
    }
}
