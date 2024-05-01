using Manager;
using Unity.VisualScripting;
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



        [Header("OtherProperties")]

        [SerializeField] private float ableObjectDistance = 2f;

        

        [Header("Objects")]

        [SerializeField] private GameObject paperObject;
        [SerializeField] private Image paperImage;


        [SerializeField] private GameObject trueCable;


        public Animator boxAnimator;



#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||


bool kablo = false;


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
            if(_inventoryBox == null)
            {
                Debug.Log("<color=red>Inventory Full!</color>");
                return;
            }
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
                    inventoryItem._inventoryItemImage.enabled = false;
                    inventoryItem._item = null;
                }
            }
        }


        internal Item SearchItem(string itemName)
        {
            foreach(InventoryItem inventoryItem in this.inventoryItems)
            {
                if (inventoryItem._item == null) continue;

                if (inventoryItem._item._itemName == itemName)
                {
                    return inventoryItem._item;
                }
            }
            return null;
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







        #region Events!

        public void ItemToUse(InventoryItem inventoryItem)
        {
            if (inventoryItem._item != null)
            {
                switch (inventoryItem._item._itemType)
                {
                    case Item.ItemType.paper:
                        this.paperObject.SetActive(true);
                        this.paperImage.sprite = inventoryItem._item._itemVisible;
                        if (inventoryItem._item._cableIsTrue)
                        {
                            this.gameManager.uiManager.numberGameObject.SetActive(true);
                        }
                        else
                        {
                            this.gameManager.uiManager.numberGameObject.SetActive(false);
                        }
                        break;

                    case Item.ItemType.cable:
                        if (Vector3.Distance(this.gameManager._playerController._playerObject.transform.position, inventoryItem._item._itemAbleToGameObject.transform.position) < this.ableObjectDistance)
                        {
                            if (inventoryItem._item._cableIsTrue && inventoryItem._item._itemType != Item.ItemType.key)
                            {
                                this.trueCable.SetActive(true);
                                InventoryRemoveItem(inventoryItem._item);
                                this.gameManager.GizemliMakine9();
                                this.kablo = true;
                            }
                            else
                            {
                                Debug.Log("Yanlis Kablo!");
                                InventoryRemoveItem(inventoryItem._item);
                            }
                        }
                        else
                        {
                            Debug.Log("Obje kullanilamaz!!");
                        }
                        break;

                    case Item.ItemType.key:
                    Debug.Log("Key");
                        if (Vector3.Distance(this.gameManager._playerController._playerObject.transform.position, inventoryItem._item._itemAbleToGameObject.transform.position) < this.ableObjectDistance)
                        {
                            Debug.Log("KeyDistance");
                            
                            if (this.kablo == true)
                            {
                                Debug.Log("kablo true");
                            this.boxAnimator.SetTrigger("etkin");
                            InventoryRemoveItem(inventoryItem._item);
                            

                            }
                        }
                        break;
                }
            }
        }







        /// <summary>
        /// You can close the paper UI object with this method!
        /// </summary>
        internal bool PaperClose()
        {
            if (this.paperObject.activeSelf == true)
            {
                this.paperImage.sprite = null;
                this.paperObject.SetActive(false);
                return true;
            }
            return false;
        }

        #endregion
    }
}