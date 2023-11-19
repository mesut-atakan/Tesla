using UnityEngine;
using CameraController; // The namespace where we manage camera controls!
using Player;
using Interaction;
using Inventory;


namespace Manager
{
    internal class GameManager : MonoBehaviour
    {
#region ||~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~||
        
        
        




        [Header("Script And Classes")]


        [SerializeField] private InputManager inputManager;

        [SerializeField] private PlayerController playerController;

        [SerializeField] private CameraManager cameraManager;

        [SerializeField] private Events events;

        [SerializeField] private ItemInteraction itemInteraction;
        [SerializeField] private InventoryManager inventoryManager;

        [SerializeField] private UIManager uiManager;


        [Tooltip("Add the `Top Down Controller` class used for the Top Down Shooter perspective!")]
        [SerializeField] private TopDownCamera topDownCamera;







        [Space(10f), Header("Interaction Classes")]

        [SerializeField] private InteractionTeslaCoil interactionTeslaCoil;

        [SerializeField] private InteractionTable interactionTable;

        [SerializeField] private InteractionCable interactionCable;
      
#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||








#region ||~~~~~~~~|| PRIVATE FIELDS ||~~~~~~~~||

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||






#region ||~~~~~~~~|| PROPERTIES ||~~~~~~~~||

        internal InputManager _inputManager { get => this.inputManager; }

        internal bool _interactionItemMode { get; set; }

        internal TopDownCamera _topDownCamera
        {
            get => this.topDownCamera;
            set => this.topDownCamera = value;
        }


        internal PlayerController _playerController
        {
            get => this.playerController;
            set => this.playerController = value;
        }


        internal CameraManager _cameraManager
        {
            get => this.cameraManager;
            set => this.cameraManager = value;
        }



        internal InteractionTeslaCoil _interactionTeslaCoil
        {
            get => this.interactionTeslaCoil;
            set => this.interactionTeslaCoil = value;
        }


        internal InteractionTable _interactionTable
        {
            get => this.interactionTable;
            set => this.interactionTable = value;
        }


        internal Events _events
        {
            get => this.events;
            set => this.events = value;
        }


        internal ItemInteraction _itemInteraction
        {
            get => this.itemInteraction;
            set => this.itemInteraction = value;
        }

        internal InventoryManager _inventoryManager
        {
            get => this.inventoryManager;
            set => this.inventoryManager = value;
        }

        internal InteractionCable _interactionCable
        {
            get => this.interactionCable;
            set => this.interactionCable = value;
        }


#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||



















        private void Awake() 
        {
            this.cameraManager._activeCamera = this.cameraManager._mainCamera;
            this.playerController._isMove = true;
        }


        private void OnEnable() {
            
        }




        private void Start() {
            // MouseCursorPrivate();
        }






        private void FixedUpdate() {
            // if character go to interaction area 
            if (this.playerController._interactionMove)
            {
                this.playerController.InteractionAreaControl();
            }
        }






        private void Update() 
        {
            if (Input.GetKeyDown(this.inputManager._interactionKey))
            {
                if (!this.uiManager.mouseUI)
                {
                    this.playerController.Move();
                    

                    if (this._interactionItemMode)
                    {
                        this.itemInteraction.Interaction();
                    }
                    
                }
            }
            else if (Input.GetKeyDown(this.inputManager._secondInteractionKey))
            {
                this.playerController.Interaction();
            }
            else if (Input.GetKeyDown(this.inputManager._backKey) || Input.GetKeyDown(this.inputManager._backKey2))
            {
                this.inventoryManager.PaperClose();
                this.playerController.GoToGameCamera();
            }
        }





        private void LateUpdate() {
            this.playerController.AnimationController();
            this.topDownCamera.CameraMovement();
        }














        /// <summary>
        /// With this method, you can put the character into or out of Item Interaction mode!
        /// </summary>
        /// <param name="mode">If this parameter is true, the character switches to interaction mode; if false, the character exits interaction mode!</param>
        internal void ItemInteractionMod(bool mode)
        {
            this.playerController._isMove = !mode;
            this._interactionItemMode = mode;
        }





        /// <summary>
        /// With this method you can turn the character's appearance on and off.
        /// </summary>
        /// <param name="value"></param>
        internal void CharacterVisibleChange(bool value)
        {
            this.playerController._playerObject.SetActive(value);
        }












        private void MouseCursorPrivate()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}