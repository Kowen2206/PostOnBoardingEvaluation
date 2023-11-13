using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataStore
{
    public interface IDataStore 
    {
    void SetData<T>(T data, string key);
            T GetData<T>(string key);
    }
}

