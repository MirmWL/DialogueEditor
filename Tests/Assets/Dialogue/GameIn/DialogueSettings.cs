using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("dialogue")]
public class DialogueSettings
{
    [XmlElement("saveData")] 
    public SaveData[] SaveData;
    
    [XmlElement("node")]
    public SettingNode[] Nodes;

    public static DialogueSettings Load(TextAsset _xmlDocument)
    {
        XmlSerializer _serializer = new XmlSerializer(typeof(DialogueSettings));
        StringReader _reader = new StringReader(_xmlDocument.text);
        return _serializer.Deserialize(_reader) as DialogueSettings;
    }
}

[System.Serializable]
public class SaveData
{
    [XmlElement("json")]
    public string Json;

    [XmlElement("key")] 
    public string Key;
}


[System.Serializable]
public class SettingNode
{
    [XmlElement("connect")]
    public SettingConnect Connect;

    [XmlElement("index")]
    public int Index;

    [XmlElement("name")]
    public string Name;

    [XmlElement("phrase")]
    public string Phrase;

    [XmlElement("type")] 
    public string Type;
    
}


public class SettingConnect
{
    [XmlElement("connectToIndex")]
    public int[] ConnectIndexes;
}