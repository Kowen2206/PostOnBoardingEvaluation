using System;
using System.Collections;
using System.Collections.Generic;
using DataStore.Adapters;
using UnityEngine;

namespace DataStore
{
    public class DataManager : MonoBehaviour
    {
        private readonly IDataStore dataStore;

        public DataManager()
        {
            dataStore = new PlayerPrefsDataStoreAdapter();
        }

        public T GetData<T>(string key)
        {
           return dataStore.GetData<T>(key);
        }

        public void SetData<T>(T data, string key)
        {
            dataStore.SetData(data, key);
        }
    }

}
