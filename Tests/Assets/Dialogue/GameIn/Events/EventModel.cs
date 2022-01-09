using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class EventModel
{
    [HideInInspector]
    public int NodeIndex;
    
    public UnityEvent Event;
    
    public EventModel(int _nodeIndex)
    {
        NodeIndex = _nodeIndex;
        Event = new UnityEvent();
    } 
}