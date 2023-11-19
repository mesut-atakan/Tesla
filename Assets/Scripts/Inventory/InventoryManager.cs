using Manager;
using UnityEngine;
using UnityEngine.UI;



namespace Inventory
{
    internal class InventoryManager : MonoBehaviour
    {
#region ||~~~~~~~~|| SERIALZIE FIELDS ||~~~~~~~~||

        [Header("Scripts Or Components")]

        [SerializeField] private GameManager gameManager;

        [Header("Inventory Properties")]

        [SerializeField] private InventoryItem[] inventoryItems;



#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||





#region ||~~~~~~~~|| PROPERTIE ||~~~~~~~~||



#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||




    

    

        /// <summary>
        /// With this method, you can assign an item to an empty box in your inventory!
        /// </summary>
        internal void InventoryAddItem(Item item)
        {
            // ~~ Variables ~~
            InventoryItem _inventoryBox;
            
            _inventoryBox = InventoryIsFull();
            if(_inventoryBox == null) return;
            Debug.Log("Add Item", _inventoryBox.gameObject);
            _inventoryBox._inventoryItemImage.sprite = item._itemSprite;
            _inventoryBox._boxFull = true;
            _inventoryBox._item = item;
            _inventoryBox._inventoryItemImage.enabled = true;
        }



        /// <summary>
        /// You can delete items from the inventory with this method
        /// </summary>
        /// <param name="item">Select the object you want to delete</param>
        internal void InventoryRemoveItem(Item item)
        {
            foreach(InventoryItem inventoryItem in this.inventoryItems)
            {
                if (inventoryItem._item == item)
                {
                    inventoryItem._boxFull = false;
                    inventoryItem._inventoryItemImage.sprite = null;
                    inventoryItem._item = null;
                }
            }
        }



        /// <summary>
        /// With this method, you can check whether there is any free space in the inventory!
        /// </summary>
        /// <returns>If there is empty space in the inventory, this function will return the empty inventory!</returns>
        internal InventoryItem InventoryIsFull()
        {
            foreach(InventoryItem inventoryItem in this.inventoryItems)
            {
                if (!inventoryItem._boxFull)
                {
                    return inventoryItem;
                }
            }

            return null;
        }
    }
}