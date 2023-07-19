using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperUI : MonoBehaviour
{
    [Header("Main UI Container")]
    [SerializeField] private GameObject _mainContainer;

    [Header("Inventories")]
    [SerializeField] private Inventory _shopKeeperInventory;

    [SerializeField] private Inventory _playerInventory;
    [Header("Prefab for the Item Icon")]
    [SerializeField] private GameObject _itemPrefab;

    [Header("Transform of the layout group for the items")]
    [SerializeField] private Transform _parentTransform;

    //Internal Variables
    private List<GameObject> addedItems = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OpenSellWindow() 
    {
        ToggleMainContainer();

        ClearItems();

        AddItems(_playerInventory.items);
    }

    public void OpenBuyWindow() 
    {
        ToggleMainContainer();

        ClearItems();

        AddItems(_shopKeeperInventory.items);
    }


    public void AddItems(List<Item> items) 
    {
        foreach(Item item in items) 
        {
            
            GameObject spawnIcon = Instantiate(_itemPrefab,_parentTransform); 
            if(spawnIcon.TryGetComponent<ItemUI>(out ItemUI itemUI))
            {
                itemUI.SetupItem(item);
                addedItems.Add(spawnIcon);
            } else 
            {
                Debug.LogWarning("Current item prefab doesn't have the Item UI behavior, please add it!");
            }
        }
    }

    void OnDisable()
    {
        foreach(GameObject itemObject in this.addedItems) 
        {
            Destroy(itemObject);
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

    private void ClearItems() 
    {
        foreach(GameObject uiItem in this.addedItems) 
        {
            Destroy(uiItem);
        }
    }
}
