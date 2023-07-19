using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    // Representation of an item in game
    public Sprite ItemIcon;
    public int ItemValue;

    public string ItemName;

    public Sprite ItemSprite;
}
