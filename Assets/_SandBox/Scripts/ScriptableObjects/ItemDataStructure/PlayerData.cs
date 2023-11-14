using System.Collections;
using System.Collections.Generic;
using DataStructure.items;
using UnityEngine;

namespace DataStructure
{
    [CreateAssetMenu(fileName ="playerData", menuName = "Player")]
    public class PlayerData : ScriptableObject
    {
        //La variable playerItems se usa para guardar la ultima selección de items del usuario, la primeravez el valor es null
        [SerializeField] private List<ItemData> playerItems = null;
        [SerializeField] private int playerLvl = 1;
        public readonly string Player_key = "Player";

        public List<ItemData> PlayerItems => playerItems;

        public int PlayerLvl => playerLvl; 
    }
}



