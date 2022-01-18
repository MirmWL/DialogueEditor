using System.Collections.Generic;
using System;

[Serializable]
public class SaveData<T> where T : ISavable
{
    public List<T> SaveObjects;
    public SaveData() => SaveObjects = new List<T>();
    public void AddSavable(T _object) => SaveObjects.Add(_object);
}
   
