using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

public class NodeController
{
    public readonly NodeCreator Creator;
    public readonly NodeSelector Selector;
    public readonly NodesDrawer Drawer;

    public NodeController()
    {
        Creator = new NodeCreator();
        Selector = new NodeSelector(_nodes);
        Drawer = new NodesDrawer(_nodes);

        Creator.OnCreate += Selector.OnSelect;
    }
    
    private IReadOnlyList<Node> _nodes => Creator.Nodes;

    private Node GetStartNode()
    {
         return _nodes
            .FirstOrDefault(s => GetConnectIndexes().Contains(s.Model.Index) == false);
    }

    private IReadOnlyCollection<Node> ReplaceStartNodeToFirstPosition()
    {
        ObservableCollection<Node> _nodes = new ObservableCollection<Node>(this._nodes);
        
        _nodes
            .Move(_nodes
            .ToList()
            .FindIndex(s => s == GetStartNode()), 0);

        return _nodes;
    }

    public IReadOnlyCollection<Node> GetSortedCollection() => ReplaceStartNodeToFirstPosition();

    private IEnumerable<int> GetConnectIndexes()
    {
        foreach (Node _node in Creator.Nodes)
        {
            foreach (int _index in _node.ConnectTargetsIndexes)
                yield return _index;
        }
    }
}
