using System.Collections.Generic;
using System.Linq;

public class ConnectionController
{
    public readonly ConnectionsDrawer Drawer;
    private readonly List<Connection> _connections;

    private Node _from;
    private Node _to;
    
    private readonly ConnectionConditionsBase _conditionsBase;
    public ConnectionController()
    {     
        _connections = new List<Connection>();
        Drawer = new ConnectionsDrawer(_connections);
        _conditionsBase = new ConnectionConditionsBase(_connections);
    }

    public IReadOnlyList<Connection> Connections => _connections;
                           
    private void AddConnection()
    {
        if (GetConnectPossibility())
        {
            _from._ConnectTargetIndexes.Add(_to.Model.Index);
            _connections.Add(new Connection(new KeyValuePair<IConnectable, IConnectable>(_from, _to)));
        }
       
        _from = null;
        _to = null;
    }

    public void DeleteConnection(Node _node)
    {
        _connections
            .Where(s => s.ConnectionPair.Key == _node || s.ConnectionPair.Value == _node)
            .ToList()
            .ForEach(s =>
            {
                s.ConnectionPair.Key._ConnectTargetIndexes.Remove(_node.Model.Index);
                _connections.Remove(s);
            });
    }

    private bool GetConnectPossibility()
    {
        switch (_to._Type)
        {
            case NodeType.Speech:

                if (_conditionsBase.SpeechConditions.Invoke(_from, _to))
                    return true;
                break;

            case NodeType.Option:

                if (_conditionsBase.OptionConditions.Invoke(_from, _to))
                    return true;
                break;
        }

        return false;
    }

    public void SetTarget(Node _to)
    {
        if(_from != null)
        {
            this._to = _to;
            AddConnection();
        } 
    }

    public void SetOrigin(Node _from) => this._from = _from;

}

