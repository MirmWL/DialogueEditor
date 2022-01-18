using System.Collections.Generic;
using System;
using System.Linq;

public class ConnectionConditionsBase
{
    public readonly Func<IConnectable, IConnectable, bool> SpeechConditions;
    public readonly Func<IConnectable, IConnectable, bool> OptionConditions;

    private IReadOnlyList<Connection> _connections;

    public ConnectionConditionsBase(List<Connection> _connections)
    {
        this._connections = _connections;

        SpeechConditions = (_from, _to) => CheckSameSpeechTypeLvl(_from) && GetAddSpeechTargetPossibility(_from, _to);
        OptionConditions = (_from, _to) => CheckSameOptionTypeLvl(_from) && GetAddOptionTargetPossibility(_from, _to); 
    }

    private bool CheckSameSpeechTypeLvl(IConnectable _from)
    {
        return GetConnectionTargets(_from).All(s => s._Type == NodeType.Speech);
    }

    private bool CheckSameOptionTypeLvl(IConnectable _from)
    {
        return GetConnectionTargets(_from).All(s => s._Type == NodeType.Option);
    }

    private bool GetAddSpeechTargetPossibility(IConnectable _from, IConnectable _to)
    {
        return _to._Type == NodeType.Speech && _from._ConnectTargetIndexes.Count == 0;
    }

    private bool GetAddOptionTargetPossibility(IConnectable _from, IConnectable _to)
    {
        return _from._Type != NodeType.Option && _to._Type == NodeType.Option;
    }

    private IEnumerable<IConnectable> GetConnectionTargets(IConnectable _from)
    {
        foreach (Connection _connection in _connections)
        {
            if (_connection.ConnectionPair.Key == _from)
                yield return _connection.ConnectionPair.Value;
        }
    }

}
