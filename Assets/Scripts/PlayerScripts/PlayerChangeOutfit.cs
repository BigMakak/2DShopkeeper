using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeOutfit : MonoBehaviour
{
    // List of the AnimatiorControllers that represent certains items that the player can equip
    [SerializeField] private List<ItemAnimation> itemAnimations = new List<ItemAnimation>();
    // Internal Variables
     private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Changes the outfit, based on the item that was pressed by the player
    public void ChangeOutfit(Item item) 
    {
        animator.runtimeAnimatorController = itemAnimations.Find(itemAnim => itemAnim.item == item).animatorController;
    }
}

[System.Serializable]
public struct ItemAnimation 
{
    public Item item;

    public RuntimeAnimatorController animatorController;
}
