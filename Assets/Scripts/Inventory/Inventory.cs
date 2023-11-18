using UnityEngine;



namespace Inventory
{
    internal class Inventory : MonoBehaviour
    {
#region ||~~~~~~~~|| SERIALZIE FIELDS ||~~~~~~~~||

        [Header("Inventory Properties")]

        [SerializeField] private InventoryItem[] inventoryItems;


#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||




    

    

        /// <summary>
        /// Bu metod ile envanterinizde bos olan bir kutuya item atayabilirsiniz!
        /// </summary>
        internal void InventoryAddItem()
        {
            // ~~ Variables ~~
            InventoryItem _inventoryItem;
            
            _inventoryItem = InventoryIsFull();
            if (_inventoryItem == null) return;     // Inventory Is Full!

            _inventoryItem._boxFull = true;
            _inventoryItem._inventoryItemImage.sprite = _inventoryItem._item._itemSprite;
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