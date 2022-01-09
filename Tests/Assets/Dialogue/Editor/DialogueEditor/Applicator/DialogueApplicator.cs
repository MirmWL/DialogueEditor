using System.Linq;
using System.Collections.Generic;
using System;

public class DialogueApplicator
{
    public Func<IReadOnlyList<Node>> RequireSortedNodes;
    
    private readonly XmlConverter _converter;
    public DialogueApplicator() => _converter = new XmlConverter();
    
    public void Apply(string _path)
    {
        _converter.SetFilePath(_path);
        _converter.AddNodes(RequireSortedNodes.Invoke().ToList());
    }
}
