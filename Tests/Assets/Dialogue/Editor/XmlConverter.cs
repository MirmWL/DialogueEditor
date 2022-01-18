using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class XmlConverter
{
    private XmlDocument _document;
    private StringBuilder _builder;

    private string _path;
    private Dictionary<string, string> _saveData;
    
    public XmlConverter()
    {
        _document = new XmlDocument();
        _builder = new StringBuilder();
        _saveData = new Dictionary<string, string>();
        
        Instance = this;
    }

    public static XmlConverter Instance { get; private set; }
    public void AddJson(string _key, string _json)
    {
        if(_saveData.ContainsKey(_key) == false)
            _saveData.Add(_key, _json);
    }

    public void Convert(List<Node> _nodes)
    {
        _builder.Append("<?xml version=\"1.0\"?>");
        _builder.Append("<dialogue>");
        AddSaveBlocks();
        AddNodes(_nodes);
        _builder.Append("</dialogue>");
        Save();
    }
    
    private void AddNodes(List<Node> _nodes) => _nodes.ForEach(s => AddNode(s));

    private void AddSaveBlocks()
    {
        foreach (KeyValuePair<string,string> _pair in _saveData)
        {
            _builder.Append("<saveData>");
            _builder.Append($"<key>{_pair.Key}</key>");
            _builder.Append($"<json>{_pair.Value}</json>");
            _builder.Append("</saveData>");
        }
    }
    
    private void AddNode(Node _node)
    {
        _builder.Append("<node>");

        _builder.Append($"<connect>");
        _node._ConnectTargetIndexes.ForEach(s => _builder.Append($"<connectToIndex>{s}</connectToIndex>"));
        _builder.Append($"</connect>");

        _builder.Append($"<index>{_node.Model.Index}</index>");
        _builder.Append($"<name>{_node.Model.Name}</name>");
        _builder.Append($"<phrase>{_node.Model.Phrase}</phrase>");
        _builder.Append($"<type>{_node._Type}</type>");

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
