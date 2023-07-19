using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        if (_mainContainer == null)
        {
            Debug.Log("No Main container defined for the Player Inventory UI");
            return;
        }

        this._mainContainer.SetActive(!this._mainContainer.activeSelf);

        if (this._mainContainer.activeSelf)
        {
            ClearItems();

            addItemsToInventory();
        }
    }

    private void addItemsToInventory()
    {

        foreach (Item item in _playerInventory.items)
        {

            if (_addedItems.Contains(item))
            {
                return;
            }

            GameObject currObj = Instantiate(UIPrefab, _layoutContainer);

            if (currObj.TryGetComponent<ItemUI>(out ItemUI itemUI))
            {
                itemUI.SetupItem(item, OnButtonClicked);
                _addedItems.Add(item);
            }
        }
    }


    private void OnButtonClicked(Item item)
    {
        Debug.Log("On clicked item: " + item.name + " || Player Object: " + _playerObject.name);
        if (_playerObject == null)
        {
            Debug.LogWarning("No player Object found, please add the player tag to the player");
        }

        if (_playerObject.TryGetComponent<PlayerChangeOutfit>(out PlayerChangeOutfit playerChangeOutfit))
        {
            playerChangeOutfit.ChangeOutfit(item);
        }
        else
        {
            Debug.LogWarning("Player Object doesn't have a Player Change Outfit component, please add it!");
        }
    }

    private void ClearItems() 
    {
        Debug.Log("On Clear Items Player UI");

        int childCount = _layoutContainer.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Destroy(_layoutContainer.GetChild(i).gameObject);
        }

        this._addedItems.Clear();
    }
}
