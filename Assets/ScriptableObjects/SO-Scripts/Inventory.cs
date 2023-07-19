using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Inventory", menuName = "ScriptableObjects/Inventory")]
public class Inventory : ScriptableObject
{
   public List<Item> items;
}
