using System.Linq;
using System.Collections.Generic;
using System;

public class DialogueApplicator
{
    public Func<IReadOnlyCollection<Node>> RequireSortedNodes;
    
    public void Apply(string _path)
    {
        XmlConverter.Instance.SetFilePath(_path);
        XmlConverter.Instance.Convert(RequireSortedNodes.Invoke().ToList());
    }
}
