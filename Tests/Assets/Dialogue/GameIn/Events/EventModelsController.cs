using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventModelsController : MonoBehaviour
{
    public List<EventModel> EventModels;
    public void Execute(int _nodeIndex)
    {
        EventModels
            .FirstOrDefault(s => s.NodeIndex == _nodeIndex)?
            .Event.Invoke();
    }
    
    public void Remove(int _nodeIndex)
    {
        EventModels.Remove(EventModels.FirstOrDefault(s => s.NodeIndex == _nodeIndex));
    }
    
    public void Add(int _nodeIndex) => EventModels.Add(new EventModel(_nodeIndex));
    public void Init() => EventModels.RemoveAll(s => true);
    
}
