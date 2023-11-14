using System.Collections;
using System.Collections.Generic;
using DataStructure.items;
using UnityEngine;



namespace DataStructure
{
    [CreateAssetMenu(fileName ="itemData", menuName = "Items")]
    
    public class ItemData : ScriptableObject
    {
        [SerializeField] private string _itemName;
        [SerializeField] private int _requiredLevel;
        [SerializeField] private ItemTypes _type;
        [SerializeField] private ItemTypes _weakAgainst;
        [SerializeField] private ItemTypes _strongAgainst;
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private Sprite _sprite;

        public string ItemName => _itemName; 
        public int RequiredLevel => _requiredLevel; 
        public ItemTypes Type => _type; 
        public ItemTypes WeakAgainst => _weakAgainst;
        public ItemTypes StrongAgainst => _strongAgainst; 
        public GameObject ItemPrefab => _itemPrefab;
        public Sprite Sprite => _sprite;
    }

}
