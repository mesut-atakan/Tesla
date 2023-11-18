using UnityEngine;



namespace Inventory
{
    internal class InventoryManager : MonoBehaviour
    {
#region ||~~~~~~~~|| SERIALZIE FIELDS ||~~~~~~~~||

        [Header("Inventory Properties")]

        [SerializeField] private InventoryItem[] inventoryItems;


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