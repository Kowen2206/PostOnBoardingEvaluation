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
        private List<ItemTypes> playerItems = null;
        private int playerLvl = 1;

    }
}



