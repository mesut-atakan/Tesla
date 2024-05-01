using UnityEngine;
using CameraController; // The namespace where we manage camera controls!
using Player;
using Interaction;
using Inventory;
using UnityEngine.AI;
using UnityEngine.Events;


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

        [SerializeField] public UIManager uiManager;


        [Tooltip("Add the `Top Down Controller` class used for the Top Down Shooter perspective!")]
        [SerializeField] private TopDownCamera topDownCamera;







        [Space(10f), Header("Interaction Classes")]

        [SerializeField] private InteractionTeslaCoil interactionTeslaCoil;

        [SerializeField] private InteractionTable interactionTable;

        [SerializeField] private InteractionCable interactionCable;
        public InteractionTelegraf interactionTelegraf;
        public InteractionNeon interactionNeon;
        public InteractionTimeMachine interactionTimeMachine;
        



        [Header("Gizemli Makine 9")]

        public GameObject number9FalseLight;
        public GameObject number9TrueLight;


        public MeshRenderer number9FalseMaterial;
        public Material number9TrueMaterial;




        [Header("Events")]

        public UnityEvent escapeEvent;







        [Space(30f)]

        public GameObject Key;


        public GameObject neonUI;
      
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



















        [System.Obsolete]
        private void Awake() 
        {
            this.cameraManager._activeCamera = this.cameraManager._mainCamera;
            this.playerController._isMove = true;
            Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen, 60);


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
                // variables
                 this.inventoryManager.PaperClose();
                bool _gamePauseControl = this.playerController.GoToGameCamera();

                if (_gamePauseControl == false)
                    this.escapeEvent.Invoke();
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






        internal void GizemliMakine9()
        {
            this.number9FalseLight.SetActive(false);
            this.number9TrueLight.SetActive(true);
            this.number9FalseMaterial.material = this.number9TrueMaterial;
        }
    }
}