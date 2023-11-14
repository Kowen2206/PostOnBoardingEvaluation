using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.Events;

public class UserMessage : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _messageTextMesh;
        [SerializeField] private Button _messageButton;
        [SerializeField] private CanvasGroup _messagePrefab;

        public void Awake()
        {
            Hide();
            OnClickAceptMessage(Hide);
        }

        public void Show(string message = "Error desconocido")
        {
            _messageTextMesh.text = message;
            _messagePrefab.gameObject.SetActive(true);
            _messagePrefab.alpha = 1;
        }

        public void Hide()
        {
            _messagePrefab.gameObject.SetActive(false);
            _messagePrefab.alpha = 0;
        }

        public void OnClickAceptMessage(UnityAction cb)
        {
           _messageButton.onClick.AddListener(cb);
        }
        
    }
