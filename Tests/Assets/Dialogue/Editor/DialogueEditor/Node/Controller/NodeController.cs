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
        Selector = new NodeSelector(Nodes);
        Drawer = new NodesDrawer(Nodes);

        Creator.OnCreate += Selector.OnSelect;
    }

    public IReadOnlyList<Node> Nodes => Creator.Nodes;

    public IReadOnlyList<Node> GetSorted()
    {
        ObservableCollection<Node> _observableNodes = new ObservableCollection<Node>(Nodes);

        Node _nodeWithoutOrigin = _observableNodes
            .FirstOrDefault(s => GetConnectIndexes().Contains(s.Model.Index) == false);

        _observableNodes.Move(_observableNodes
            .ToList()
            .FindIndex(s => s == _nodeWithoutOrigin), 0);

        return _observableNodes.ToList();
    }

    private IEnumerable<int> GetConnectIndexes()
    {
        foreach (Node _node in Creator.Nodes)
        {
            foreach (int _index in _node.ConnectTargetsIndexes)
                yield return _index;
        }
    }
}
