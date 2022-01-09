using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection
{ 
    public KeyValuePair<IConnectable, IConnectable> ConnectionPair { get; private set; }
    public ConnectionDrawModel DrawModel;

    public Connection(KeyValuePair<IConnectable, IConnectable> _connection)
    {
        ConnectionPair = _connection;
        DrawModel = new ConnectionDrawModel(ConnectionPair);
    }

}
