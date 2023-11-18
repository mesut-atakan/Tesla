using Inventory;
using Manager;
using UnityEngine;



namespace Player
{
    internal class ItemInteraction : MonoBehaviour
    {
#region ||~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~||
        [Header("Classes or Components")]

        [SerializeField] private GameManager gameManager;
        
        [SerializeField] private new Camera camera;

        [SerializeField] private LayerMask interactionLayer;

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||









#region ||~~~~~~~~|| PRIVATE FIELDS ||~~~~~~~~||

        private Ray _ray;
        private RaycastHit _hit;
        private Vector3 _mousePosition;

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||





#region ||~~~~~~~~|| PROPERTIES ||~~~~~~~~||

        internal Camera _camera
        {
            get => this.camera;
            set => this.camera = value;
        }

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||











        /// <summary>
        /// This method will allow you to interact with items!
        /// </summary>
        internal void Interaction()
        {
            // ~~ Variables ~~
            Item _inventoryItem;


            this._mousePosition = Input.mousePosition;
            this._ray = this.camera.ScreenPointToRay(this._mousePosition);

            if (Physics.Raycast(_ray, out this._hit, Mathf.Infinity, this.interactionLayer))
            {
                Debug.DrawRay(_ray.origin, _hit.point, Color.gray, 2f);
                if (_hit.collider.CompareTag("Item"))
                {
                    _inventoryItem = this._hit.collider.gameObject?.GetComponent<Item>();
                    if (_inventoryItem != null)
                    {
                        _inventoryItem.gameObject.SetActive(false);
                    }

                }
            }
        }
    }
}