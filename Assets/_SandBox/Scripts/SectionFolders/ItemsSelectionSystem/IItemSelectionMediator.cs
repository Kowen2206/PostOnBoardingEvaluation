using System.Collections;
using System.Collections.Generic;
using DataStore;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DataStructure;

namespace SelectionSystem
{
    public interface IItemSelectionMediator
    {
        int RequiredCountSelection { get;}
        public TextMeshProUGUI MessageTextMesh { get; }
        public Button MessageButton { get; }
        public CanvasGroup MessagePrefab { get; }

        public PlayerData PlayerData { get; }
        public Button ContinueButton { get; }

        void OnFailTryContinue();

        void OnRebaseSelectionLimit();
        void OnTrySelectItemOutOfLvl();
    }
}
