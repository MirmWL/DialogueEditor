using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class XmlConverter
{
    private XmlDocument _document;
    private StringBuilder _builder;

    private string _path;

    public XmlConverter()
    {
        _document = new XmlDocument();
        _builder = new StringBuilder();
    }

    public void AddNodes(List<Node> _nodes)
    {
        _builder.Append("<?xml version=\"1.0\"?>");
        _builder.Append("<dialogue>");
        _nodes.ForEach(s => AddNode(s));
        _builder.Append("</dialogue>");

        Save();
    }

    private void AddNode(Node _node)
    {
        _builder.Append("<node>");

        _builder.Append($"<connect>");
        _node.ConnectTargetsIndexes.ForEach(s => _builder.Append($"<connectToIndex>{s}</connectToIndex>"));
        _builder.Append($"</connect>");

        _builder.Append($"<index>{_node.Model.Index}</index>");
        _builder.Append($"<name>{_node.Model.Name}</name>");
        _builder.Append($"<phrase>{_node.Model.Phrase}</phrase>");
        _builder.Append($"<type>{_node.Type}</type>");

        _builder.Append("</node>");
    }

    public void SetFilePath(string _path)
    {
        if (Path.GetExtension(_path) == ".xml")
            this._path = _path;
        else
            throw new System.ArgumentException("File extension is not xml");
    }

    private void Save()
    {   
        _document.LoadXml(_builder.ToString());
        _document.Save(_path);

        _builder.Clear();
    }

}
