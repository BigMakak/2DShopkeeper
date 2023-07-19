using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{

    [Header("UI Elements")]
    [SerializeField] private GameObject _mainContainer;

    [SerializeField] private Transform _layoutContainer;

    [Header("Prefabs")]
    [SerializeField] private GameObject UIPrefab;

    [Header("Inventory")]

    [SerializeField] private Inventory _playerInventory;


    // Internal Variables
    private GameObject _playerObject;

    private List<Item> _addedItems = new List<Item>();

    void Start()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    public void ToogleInventoryWindow() 
    {
        if(_mainContainer == null) 
        {
            Debug.Log("No Main container defined for the Player Inventory UI");
            return;
        }

        this._mainContainer.SetActive(!this._mainContainer.activeSelf);

        if(this._mainContainer.activeSelf) 
        {
            addItemsToInventory();
        }
    }

    private void addItemsToInventory() 
    {
        foreach(Item item in _playerInventory.items) 
        {

            if(_addedItems.Contains(item)) 
            {
                return;
            }

            GameObject currObj = Instantiate(UIPrefab,_layoutContainer);

            if(currObj.TryGetComponent<ItemUI>(out ItemUI itemUI)) 
            {
                itemUI.SetupItem(item,OnButtonClicked);
                _addedItems.Add(item);
            }
        }
    }


    private void OnButtonClicked(Item item) 
    {
        Debug.Log("On clicked item: " + item.name + " || Player Object: " + _playerObject.name);
    }

    void OnDisable()
    {
        int childCount = _layoutContainer.childCount;

        for(int i = 0; i < childCount; i++) 
        {
            Destroy(_layoutContainer.GetChild(i));
        }

        this._addedItems.Clear();
    }
}
