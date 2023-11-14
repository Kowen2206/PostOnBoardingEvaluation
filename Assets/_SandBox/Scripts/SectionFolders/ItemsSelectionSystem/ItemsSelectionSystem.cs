using System.Collections;
using System.Collections.Generic;
using DataStore;
using DataStructure;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

namespace SelectionSystem
{
    public class ItemsSelectionSystem : MonoBehaviour, IItemSelectionMediator
    {
        [SerializeField] private GameObject _ItemCardPrefab;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Transform _availableItemsContainer;
        [SerializeField] private Transform _selectedItemsContainer;

        [SerializeField] private int _requiredCountSelection = 3;

        //Componentes del messagePrefab
        [SerializeField] private TextMeshProUGUI _messageTextMesh;
        [SerializeField] private Button _messageButton;
        [SerializeField] private CanvasGroup _messagePrefab;
        

        private ItemsController itemsController;
        private MessageController messageController;
        private ContinueButtonController continueButtonController;

        private List<ItemData> items;
        private PlayerData playerData;

        public int RequiredCountSelection { get => _requiredCountSelection;}
        public TextMeshProUGUI MessageTextMesh { get => _messageTextMesh; }
        public Button MessageButton { get => _messageButton; }
        public CanvasGroup MessagePrefab { get => _messagePrefab; }

        public PlayerData PlayerData { get => playerData; }
        public Button ContinueButton { get => _continueButton; }

        public void Awake()
        {
            items = DataManager.Instance.ItemsData;
            playerData = DataManager.Instance.PlayerData;

            itemsController = new ItemsController
                (this, playerData, items, _availableItemsContainer, _selectedItemsContainer, _ItemCardPrefab);
                itemsController.LoadItemsToSelect();
                itemsController.LoadSavedSelectedItems();
                
            messageController = new MessageController(this);

            continueButtonController = new ContinueButtonController(this, OnPressContinue);
        }

        public void OnRebaseSelectionLimit()
        {
            ThrowMessage($"No puedes seleccionar más de {RequiredCountSelection} pokemon");
        }

        public void OnPressContinue()
        {
            continueButtonController.TryToContinue();
        }

        public void OnFailTryContinue()
        {
            ThrowMessage("debes elegir al menos 3 pokemons");
        }

        public void OnTrySelectItemOutOfLvl()
        {
            ThrowMessage("Necesitas subir de nivel para seleccionar este pokemon");
        }

        public void ThrowMessage(string message)
        {
            messageController.ConfigureMessage(message);
            messageController.ShowMessage();
            MessageButton.onClick.AddListener(messageController.HideMessage);
        }
    }
}


