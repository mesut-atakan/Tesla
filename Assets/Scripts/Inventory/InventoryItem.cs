using UnityEngine;
using UnityEngine.UI;



namespace Inventory
{
    internal class InventoryItem : MonoBehaviour
    {
#region ||~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~||
        
        [Header("Box Properties")]
        [SerializeField] private bool boxFull = false;

        [SerializeField] private Image itemImage;



        [Space(30f)]
        [SerializeField] private Item item;

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||



#region ||~~~~~~~~|| PROPERTIES ||~~~~~~~~||

        internal bool _boxFull 
        {
            get => this.boxFull;
            set => this.boxFull = value;
        }

        internal Item _item
        {
            get => this.item;
            set => this.item = value;
        }

        internal Image _inventoryItemImage
        {
            get => this.itemImage;
            set => this.itemImage = value;
        }

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||
    
    }
}