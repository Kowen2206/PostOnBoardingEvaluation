using System;
using System.Collections;
using System.Collections.Generic;
using DataStore.Adapters;
using DataStructure;
using UnityEngine;

namespace DataStore
{
    public class DataManager : MonoBehaviour
    {

        
        private static DataManager instance;
        [SerializeField] private List<ItemData> _items;
        [SerializeField] private PlayerData _playerData;
        private IDataStore dataStore;

        public static DataManager Instance => instance;
        public PlayerData PlayerData => _playerData;
        public List<ItemData> ItemsData => _items;

        public void Awake()
        {
            if(instance == null)
            {
                instance = this;
                InitializeData();
            }
            else
            {
                Destroy(this);
            }
        }

        private void InitializeData()
        {
            dataStore = new PlayerPrefsDataStoreAdapter();
        }

        public T GetPlayerData<T>(string key)
        {
           return dataStore.GetData<T>(key);
        }

        public void SetData<T>(T data, string key)
        {
            dataStore.SetData(data, key);
        }
    }

}
