public class LoadNeeds
{
    public readonly ConnectionController ConnectionController;
    public readonly NodeCreator NodeCreator;
    
    public LoadNeeds(ConnectionController _connectionController, NodeCreator _nodeCreator)
    {
        NodeCreator = _nodeCreator;
        ConnectionController = _connectionController;
    }
}
