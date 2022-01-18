using System;
using System.Collections.Generic;

public class UnloadBehaviour<T> where T : ISavable
{    
    private readonly Unloader _unloader;
     
    public UnloadBehaviour(Unloader _unloader)
    {
        this._unloader = _unloader;
        Unload += GetUnloaded;
    }

    public Func<string, string, IEnumerable<T>> Unload { get; set; }
    private IEnumerable<T> GetUnloaded(string _key, string _path)
    {
        if (_unloader.Unload<SaveData<T>>(_key, _path)?.SaveObjects != null)
        {
            foreach (T _savable in _unloader.Unload<SaveData<T>>(_key, _path).SaveObjects)
            {
                InitUnloadedItem(_savable);
                yield return _savable;
            }    
        }
    }
    
    private void InitUnloadedItem(ISavable _item) => _item.Init();
}
