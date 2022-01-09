using UnityEngine;
using System.Collections.Generic;
public interface IConnectable
{
    List<int> ConnectTargetsIndexes { get; set; }
    NodeType Type { get; }
    Rect Rect { get; }
}
