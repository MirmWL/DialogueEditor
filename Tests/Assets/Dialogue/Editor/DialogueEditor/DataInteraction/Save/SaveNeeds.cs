using System.Collections.Generic;

namespace Dialogue.Editor.DialogueEditor.DataInteraction
{
    public class SaveNeeds
    {
        public IReadOnlyList<Connection> Connections;
        public IReadOnlyList<Node> Nodes;
        
        public SaveNeeds(IReadOnlyList<Connection> _connections, IReadOnlyList<Node> _nodes, NodeCreator _creator)
        {
            Nodes = _nodes;
            Connections = _connections;
        }

    }
}