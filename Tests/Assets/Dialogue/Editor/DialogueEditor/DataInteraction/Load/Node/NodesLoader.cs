using System.Collections.Generic;
using System.Linq;

public class NodesLoader : ILoader<Node>
{
    private readonly NodeCreator _creator;
    public NodesLoader(NodeCreator _creator)
    {
        this._creator = _creator;
    }

    void ILoader<Node>.Load(IEnumerable<Node> _unloaded)
    {
        _unloaded?.ToList().ForEach(s => _creator.Create(s));
    }
}
