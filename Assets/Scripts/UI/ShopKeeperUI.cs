using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeperUI : MonoBehaviour
{
    [Header("UI Variables")]
    [SerializeField] private GameObject _mainContainer;

    [SerializeField] private Image _backgroundImage;

    [Header("Inventories")]
    [SerializeField] private Inventory _shopKeeperInventory;

    [SerializeField] private Inventory _playerInventory;
    [Header("Prefab for the Item Icon")]
    [SerializeField] private GameObject _itemPrefab;

    [Header("Transform of the layout group for the items")]
    [SerializeField] private Transform _parentTransform;

    [SerializeField] private Color BuyColor;

    [SerializeField] private Color SellColor;

    //Internal Variables
    private List<UIItem> addedItems = new List<UIItem>();

    // Opens the buy window of the shoop keeper
    // Shows the items that the shopkeeper has
    public void OpenBuyWindow(Inventory openInventory) 
    {
        ToggleMainContainer();

        ClearItems();

        AddItems(openInventory,_playerInventory);
    }

    // Opens the sell window, showing the items that the player can sell
    public void OpenSellWindow(Inventory openInventory) 
    {
        ToggleMainContainer();

        ClearItems();

        AddItems(openInventory,_shopKeeperInventory);
    }

    public void ChangeWindowColor(bool isBuy) 
    {
        if(_backgroundImage == null) 
        {
            Debug.LogWarning("No back image setted in shop keeper UI, skipping behavior!");
            return;
        }

        _backgroundImage.color = isBuy ? BuyColor : SellColor;
    }

    private void AddItems(Inventory openInventory, Inventory addInventory) 
    {
        foreach(Item item in openInventory.items) 
        {
            GameObject spawnIcon = Instantiate(_itemPrefab,_parentTransform); 
            if(spawnIcon.TryGetComponent<ItemUI>(out ItemUI itemUI))
            {
                itemUI.SetupItem(item,addInventory,InterchangeItems);
                addedItems.Add(new UIItem(spawnIcon,item,openInventory));
            } else 
            {
                Debug.LogWarning("Current item prefab doesn't have the Item UI behavior, please add it!");
            }
        }
    }

    private void ToggleMainContainer() 
    {
        if(_mainContainer == null) 
        {
            Debug.LogWarning("No Main container assigned, the UI will not function has expected");
            return;
        }

        _mainContainer.gameObject.SetActive(!_mainContainer.gameObject.activeSelf);
    }

    private void InterchangeItems(Inventory addInventory,Item item) 
    {
        if(addInventory.AddItem(item)) 
        {
            Debug.Log("Item added to an Invenotry");
            UIItem currItem = this.addedItems.Find(currUIItem => currUIItem.representingItem == item);

            // Clear and destroy the representation of the UI Object
            // Also destroys the prefab that was spawned
            Destroy(currItem.uiObject);
            currItem.currInventory.RemoveItem(item);
            this.addedItems.Remove(currItem);

        } else 
        {
            Debug.Log("Not enough money to transfer the item");
        }
    }

    private void ClearItems() 
    {
        foreach(UIItem uiItem in this.addedItems) 
        {
            Destroy(uiItem.uiObject);
        }

        this.addedItems.Clear();
    }
}

public struct UIItem 
{
    public GameObject uiObject;
    public Item representingItem;

    public Inventory currInventory;

    public UIItem(GameObject gameObject, Item item, Inventory inventory) 
    {
        this.uiObject = gameObject;
        this.representingItem = item;
        this.currInventory = inventory;
    }
}


