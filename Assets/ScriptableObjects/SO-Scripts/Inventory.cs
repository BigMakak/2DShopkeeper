using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Inventory", menuName = "ScriptableObjects/Inventory")]
public class Inventory : ScriptableObject
{
   public List<Item> items;

   public int Money;

   public bool AddItem(Item item) 
   {
      this.Money -= item.ItemValue;
      if(this.Money <= 0) 
      {
         this.Money = 0;
         return false;
      }

      this.items.Add(item);
      return true;
   }

   public bool RemoveItem(Item item) 
   {
      if(!this.items.Contains(item)) 
      {
         return false;
      }

      this.Money += item.ItemValue;
      this.items.Remove(item);
      return true;
   }
}
