using System.Collections.Generic;

public class NodeSaveBehaviour : SaveBehaviour<Node>
{
    public NodeSaveBehaviour(Saver _saver, IEnumerable<Node> _sequence) : base(_saver, _sequence)
    {
    }

    public override string SaveKey { get; set; } = "NodeSaveData";
}
