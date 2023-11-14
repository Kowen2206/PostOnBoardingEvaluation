

using DataStructure;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class ItemPrefab : MonoBehaviour
{
    public ItemData Data{get; set;}
    [SerializeField] private Image image;
    [SerializeField] private Button _addButton;
    [SerializeField] private TextMeshProUGUI _textMesh;
    

    public Button AddButton => _addButton;

    

    public void LoadData(ItemData data)
    {
        Data = data;
        image.sprite = Data.Sprite;
        _textMesh.text = Data.name;
    }

    public void OnClick(UnityAction method)
    {
        _addButton.onClick.AddListener(method);
    }

    public void RemoveListeners()
    {
        _addButton.onClick.RemoveAllListeners();
    }

    public void LoadModel(Transform parent)
    {
       // Instantiate(Data.Model, parent);
    }
}