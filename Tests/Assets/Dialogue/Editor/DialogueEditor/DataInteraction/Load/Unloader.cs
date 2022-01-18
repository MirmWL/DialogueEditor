using UnityEngine;
using System.Xml.Serialization;
using System.Linq;
using System.Xml;

public class Unloader
{
    public T Unload<T>(string _key, string _xmlPath)
    {
        XmlReader _xmlReader = XmlReader.Create(_xmlPath);
        XmlSerializer _serializer = new XmlSerializer(typeof(DialogueSettings));
        DialogueSettings _dialogueSettings = _serializer.Deserialize(_xmlReader) as DialogueSettings;
        
        T _savedObject = JsonUtility.FromJson<T>(_dialogueSettings.SaveData?.FirstOrDefault(s => s.Key == _key)?.Json);
        _xmlReader.Dispose();
        return _savedObject;
    }
}
