
using System.Collections.Generic;

public class LoadController
{
    private readonly Unloader _unloader;

    private readonly ILoader<Node> _nodesLoader;
    private readonly ConnectionsInitializer _connectionsInitializer;
    
    private readonly UnloadBehaviour<Node> _nodeUnloadBehaviour;
    private readonly LoadNeeds _loadNeeds;
    public LoadController(LoadNeeds _loadNeeds)
    {
        this._loadNeeds = _loadNeeds;
        
        _unloader = new Unloader();
        _nodeUnloadBehaviour = new UnloadBehaviour<Node>(_unloader);

        _nodesLoader = new NodesLoader(_loadNeeds.NodeCreator);
        _connectionsInitializer = new ConnectionsInitializer(_loadNeeds.ConnectionController);
    }

    public void Load(string _path)
    {
        string _nodeSaveKey = new NodeSaveBehaviour(null, null).SaveKey;
        
        _nodesLoader.Load(_nodeUnloadBehaviour.Unload.Invoke(_nodeSaveKey, _path));
        _connectionsInitializer.Init(_loadNeeds.NodeCreator.Nodes);
    }
}
