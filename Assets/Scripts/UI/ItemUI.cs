using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ItemUI : MonoBehaviour
{
    
    // References for the components for the Item in the UI
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemCost;

    [SerializeField] private Button clickButton;

    public void SetupItem(Item item,Inventory addInventory, Action<Inventory,Item> OnButtonClick) 
    {
        this._itemIcon.sprite = item.ItemIcon;
        this._itemName.text = item.ItemName;
        this._itemCost.text = item.ItemValue.ToString();

        this.clickButton.onClick.AddListener(delegate { OnButtonClick(addInventory,item); });
    }

    public void SetupItem(Item item, Action<Item> OnButtonClick) 
    {
        this._itemIcon.sprite = item.ItemIcon;
        this._itemName.text = item.ItemName;
        this._itemCost.text = item.ItemValue.ToString();

        this.clickButton.onClick.AddListener(delegate { OnButtonClick(item); });
    }
}
