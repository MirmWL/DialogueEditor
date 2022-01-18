using System.Collections.Generic;

public interface ILoader<T> where T : ISavable
{
    void Load(IEnumerable<T> _unloaded);
}
