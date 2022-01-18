using System;
using System.Collections.Generic;

[Serializable]
public class NodeModel
{
    [NonSerialized]
    public NodeStateType State;
    
    public string Name;
    public string Phrase;
    public int Index;
    public NodeType Type;
    public List<int> ConnectTargetsIndexes = new List<int>();
}
