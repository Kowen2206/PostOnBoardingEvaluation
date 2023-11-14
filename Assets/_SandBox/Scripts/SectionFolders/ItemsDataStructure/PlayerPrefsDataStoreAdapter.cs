using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataStore.Adapters
{
    public class PlayerPrefsDataStoreAdapter : IDataStore
    {
        public void SetData<T>(T data, string key)
        {
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
        }

        public T GetData<T>(string key)
        {
            var json = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<T>(json);
        }

    }
}
    
