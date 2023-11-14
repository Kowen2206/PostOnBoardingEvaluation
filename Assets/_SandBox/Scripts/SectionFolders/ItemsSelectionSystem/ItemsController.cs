using System.Collections;
using System.Collections.Generic;
using DataStore;
using DataStructure;
using UnityEngine;

namespace SelectionSystem
{
    public class ItemsController
    {
        IItemSelectionMediator mediator;
        PlayerData playerData;
        List<ItemData> items;
         Transform availableItemsContainer;
        Transform selectedItemsContainer;
        GameObject itemCardPrefab;


        public ItemsController(
            IItemSelectionMediator itemsSelectionMediator,PlayerData playerData, 
            List<ItemData> items, Transform availableItemsContainer, Transform selectedItemsContainer,
            GameObject itemCardPrefab)
        {
            
            mediator = itemsSelectionMediator;
            this.playerData = playerData;
            this.items = items;
            this.itemCardPrefab = itemCardPrefab;
            this.availableItemsContainer = availableItemsContainer;
            this.selectedItemsContainer = selectedItemsContainer;
        }

        public void LoadItemsToSelect()
        {
            foreach (var item in items)
            {
                GameObject newCard = Object.Instantiate(itemCardPrefab, availableItemsContainer);
                ItemPrefab itemCard = newCard.GetComponent<ItemPrefab>();
                itemCard.LoadData(item);
                itemCard.RemoveListeners();
                itemCard.OnClick(() =>{ TryLoadLastSelectedItem(item);});
                
            }
        }

        public void LoadSavedSelectedItems()
        {
            ClearChilds(selectedItemsContainer);
            if(playerData.PlayerItems.Count <= 0) return;
            
            foreach (var item in playerData.PlayerItems)
            {
                GameObject newCard = Object.Instantiate(itemCardPrefab, selectedItemsContainer);
                newCard.GetComponent<ItemPrefab>().LoadData(item);
                ItemPrefab itemCard = newCard.GetComponent<ItemPrefab>();
                itemCard.LoadData(item);
                itemCard.RemoveListeners();
                itemCard.OnClick(() =>{ RemoveLastSelectedItem(item);});
            }
        }

        public void TryLoadLastSelectedItem(ItemData data)
        {
            if(!ValidatePlayerLvlIsEnoughtForItem(data))
            {   
                mediator.OnTrySelectItemOutOfLvl();
                return;
            }

            if(playerData.PlayerItems.Count >= mediator.RequiredCountSelection) 
            {
                mediator.OnRebaseSelectionLimit();
                return;
            }

            if(playerData.PlayerItems.Contains(data)) return;
            playerData.PlayerItems.Add(data);
            SaveSelectedItems();
            LoadSavedSelectedItems();
        }

        public void RemoveLastSelectedItem(ItemData data)
        {
            if(!playerData.PlayerItems.Contains(data)) 
            {
                return;
            }
            playerData.PlayerItems.Remove(data);
            SaveSelectedItems();
            LoadSavedSelectedItems();
        }

        public void SaveSelectedItems()
        {
            DataManager.Instance.SetData(playerData, playerData.Player_key);
        }

        public void ClearChilds(Transform parent)
        {
            foreach (Transform child in parent)
                GameObject.Destroy(child.gameObject);
        }

        public bool ValidatePlayerLvlIsEnoughtForItem(ItemData item)
        {
            return mediator.PlayerData.PlayerLvl == item.RequiredLevel;
        }
  
    }
}
