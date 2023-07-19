using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    
    // References for the components for the Item in the UI
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemCost;


    public void SetupItem(Item item) 
    {
        this._itemIcon.sprite = item.ItemIcon;
        this._itemName.text = item.ItemName;
        this._itemCost.text = item.ItemValue.ToString();
    }
}
