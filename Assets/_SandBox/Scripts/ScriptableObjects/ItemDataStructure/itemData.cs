using System.Collections;
using System.Collections.Generic;
using DataStructure.items;
using UnityEngine;



namespace DataStructure
{
    [CreateAssetMenu(fileName ="itemData", menuName = "Items")]
    public class itemData : ScriptableObject
    {
        [SerializeField] private string _itemName;
        [SerializeField] private int _requiredLevel;
        [SerializeField] private ItemTypes type;
        [SerializeField] private ItemTypes weakAgainst;
        [SerializeField] private ItemTypes strongAgainst;
        [SerializeField] private GameObject ItemPrefab;
    }

}
