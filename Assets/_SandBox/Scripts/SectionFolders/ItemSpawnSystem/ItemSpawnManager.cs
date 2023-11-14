using System.Collections;
using System.Collections.Generic;
using DataStructure;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemSpawnManager : MonoBehaviour
{
    public static ItemSpawnManager Instance;
    [SerializeField] PlayerCardsUI _playerCardsUI;
    [SerializeField] Transform _SpawnPoint;
    [SerializeField] UserMessage _userMessage;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        
    }

    private void Start()
    {
        LoadCards();
    }

    public void LoadCards()
    {
        _playerCardsUI.LoadPlayerCards();
    }

    public void OnPlayerPressCard(ItemPrefab item)
    {
        if(_SpawnPoint.childCount > 0) return;
        
        if(!CardHasRemainingUses(item))
        {
            _userMessage.Show("no puedes seguir usando este pokemon");
            return;
        }

        GameObject spawnedItem = Instantiate(item.Data.ItemPrefab, _SpawnPoint);
        spawnedItem.transform.position = _SpawnPoint.position;
        spawnedItem.GetComponent<DestroyObjectWithDelay>().Subscribe(CheckRemainingUses);

        _playerCardsUI.ItemToRemainingUses[item]--;
    }

    public bool CardHasRemainingUses(ItemPrefab item)
    {
        
        return _playerCardsUI.ItemToRemainingUses[item] > 0;
    }

    public void CheckRemainingUses()
    {
        foreach (ItemPrefab item in _playerCardsUI.ItemToRemainingUses.Keys)
        {
            if(CardHasRemainingUses(item))
            {
                return;
            }
            
        }
        _userMessage.OnClickAceptMessage(GetBackToMainScene);
        _userMessage.Show("has usado todos tus pokemon");
    }

    public void GetBackToMainScene()
    {
       SceneManager.LoadScene(0);
    }

}
