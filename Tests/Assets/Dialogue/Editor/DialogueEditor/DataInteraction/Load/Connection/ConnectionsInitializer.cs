using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConnectionsInitializer
{
    private readonly ConnectionController _controller;
    public ConnectionsInitializer(ConnectionController _controller) => this._controller = _controller;
    
    public void Init(IEnumerable<Node> _nodes)
    {
        _nodes.ToList().ForEach(s =>
        {
            foreach (int _connectIndex in s._ConnectTargetIndexes.ToList())
            {
                _controller.SetOrigin(s);
                _controller.SetTarget(_nodes.FirstOrDefault(_node => _node.Model.Index == _connectIndex));
            }
        });

    }
}
