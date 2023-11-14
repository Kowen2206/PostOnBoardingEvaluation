
using System.Diagnostics;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace SelectionSystem
{
    public class ContinueButtonController
    {
        IItemSelectionMediator mediator;
        public ContinueButtonController(IItemSelectionMediator itemsSelectionMediator, UnityAction  buttonFunc)
        {
            mediator = itemsSelectionMediator;
            mediator.ContinueButton.onClick.AddListener(buttonFunc);
        }

        public bool ValidatePlayerHasEnoughtItems()
        {
            return mediator.RequiredCountSelection == mediator.PlayerData.PlayerItems.Count;
        }

        public void TryToContinue()
        {
            if(ValidatePlayerHasEnoughtItems()) 
            {
                LoadNextScene();
            }
            else
            {
                mediator.OnFailTryContinue();
            }
        }

        public void LoadNextScene()
        {
            SceneManager.LoadScene(1);
        }

        
    }
}
