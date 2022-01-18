using System;
using System.Collections.Generic;

[Serializable]
public class Connection 
{
    public KeyValuePair<IConnectable, IConnectable> ConnectionPair;
    public Connection(KeyValuePair<IConnectable, IConnectable> _connection) => ConnectionPair = _connection;
}
