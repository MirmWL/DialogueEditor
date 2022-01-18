using System.Collections.Generic;
using System;
using System.Linq;

public abstract class SaveBehaviour<T> where T : ISavable
{
    private readonly IEnumerable<T> _sequence;
    private SaveData<T> _saveData;
    private readonly Saver _saver;
    
    public SaveBehaviour(Saver _saver, IEnumerable<T> _sequence)
    {
        this._saver = _saver;
        this._sequence = _sequence;
        _saveData = new SaveData<T>();
        
        Save += SaveSequence;
    }
    public abstract string SaveKey { get; set; }
    public Action Save { get; set; }

    private void SaveSequence()
    {
        _sequence
            .ToList()
            .ForEach(s => _saveData.AddSavable(s));
        
        _saver.Save(SaveKey, _saveData);
    }
}
