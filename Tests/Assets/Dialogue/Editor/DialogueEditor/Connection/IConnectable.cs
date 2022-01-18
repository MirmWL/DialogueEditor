using System.Collections.Generic;
using UnityEngine;


public interface IConnectable
{ 
    List<int> _ConnectTargetIndexes { get; set; }   
    Rect Rect { get;  }
    NodeType _Type { get; }
}
