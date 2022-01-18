using UnityEngine;

public class Saver
{
    public void Save<T>(string _key, T _object)
    {
        string _json = JsonUtility.ToJson(_object);
        XmlConverter.Instance.AddJson(_key, _json);
    }    
}
