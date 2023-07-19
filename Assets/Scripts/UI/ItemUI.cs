using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ItemUI : MonoBehaviour
{
    
    // References for the components for the Item in the UI
    [Header("UI Item Variables")]
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemCost;

    [SerializeField] private Button clickButton;

    [SerializeField] private Image pressedButton;

    [Header("Color Variables")]
    [SerializeField] private Color pressedColor;


    //Internal Variables

    private bool IsPressed = false;


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

    public void ToggleActiveColor() 
    {
        IsPressed = !IsPressed;

        pressedButton.color = IsPressed ? pressedColor : Color.white;
    }
}
