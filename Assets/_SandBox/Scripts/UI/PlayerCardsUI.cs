using System.Collections;
using System.Collections.Generic;
using DataStore;
using DataStructure;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCardsUI : MonoBehaviour
{
   [SerializeField] Transform _parentCards;
    private PlayerData playerData;
    [SerializeField] ItemPrefab _cardPrefab;

    private Dictionary<ItemPrefab, int> itemToRemainingUses = new Dictionary<ItemPrefab, int>();
    public Dictionary<ItemPrefab, int> ItemToRemainingUses{get => itemToRemainingUses;}

    public void Awake()
    {
        playerData = DataManager.Instance.PlayerData;
    }

    public void AddOnPressMethodToCard(ItemPrefab itemPrefab)
    {
        itemPrefab.OnClick(() => ItemSpawnManager.Instance.OnPlayerPressCard(itemPrefab));
    }
    
    public void LoadPlayerCards()
    {
        foreach (var item in playerData.PlayerItems)
        {
            GameObject card = Instantiate(_cardPrefab.gameObject, _parentCards);
            ItemPrefab newItemPrefab = card.GetComponent<ItemPrefab>();
            newItemPrefab.LoadData(item);
            itemToRemainingUses.Add(newItemPrefab, 3);
            AddOnPressMethodToCard(newItemPrefab);
        }
    }
}
