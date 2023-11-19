using UnityEngine;


namespace Inventory
{
    internal class Item : MonoBehaviour
    {
#region ||~~~~~~~~|| SERIALIZE FIELDS  ||~~~~~~~~||

        [Header("Item Properties")]


        [Tooltip("Item 3D model")]
        [SerializeField] private GameObject itemModel;


        [Tooltip("Item 2D Design")]
        [SerializeField] private Sprite itemSprite;

        [SerializeField] private string itemName;
        [SerializeField] private string itemDescription;
        [SerializeField] private bool canAddToInventory = true;
        [SerializeField] private bool canMove = false;

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||





#region ||~~~~~~~~|| PROPERTIES ||~~~~~~~~||

        internal GameObject _itemMode { get => this.itemModel; }
        internal Sprite _itemSprite { get => this.itemSprite; }
        internal string _itemName { get => this.itemName; }
        internal string _itemDescription { get => this.itemDescription; }
        internal bool _canAddToInventory { get => this.canAddToInventory; }
        internal bool _canMove { get => this.canMove; }

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||
    }
}