
using System.Diagnostics;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

namespace SelectionSystem
{
    public class MessageController
    {
        IItemSelectionMediator mediator;
        public MessageController(IItemSelectionMediator itemsSelectionMediator)
        {
            mediator = itemsSelectionMediator;
            HideMessage();
        }

        public void ConfigureMessage(string message)
        {
            mediator.MessageTextMesh.text = message?? "Error desconocido";
            mediator.MessageButton.onClick.RemoveAllListeners();
        }

        public void ShowMessage()
        {
            mediator.MessagePrefab.gameObject.SetActive(true);
            mediator.MessagePrefab.alpha = 1;
        }

        public void HideMessage()
        {
            mediator.MessagePrefab.gameObject.SetActive(false);
            mediator.MessagePrefab.alpha = 0;
        }
    }
}
