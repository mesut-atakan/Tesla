using UnityEngine;
using CameraController; // The namespace where we manage camera controls!
using Character;
using Interaction;
using UnityEditor.PackageManager;


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


        [Tooltip("Add the `Top Down Controller` class used for the Top Down Shooter perspective!")]
        [SerializeField] private TopDownCamera topDownCamera;






        [Space(10f), Header("Interaction Classes")]

        [SerializeField] private InteractionTeslaCoil interactionTeslaCoil;

        [SerializeField] private InteractionTable interactionTable;
      
#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||








#region ||~~~~~~~~|| PRIVATE FIELDS ||~~~~~~~~||

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||






#region ||~~~~~~~~|| PROPERTIES ||~~~~~~~~||

        internal InputManager _inputManager { get => this.inputManager; }

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


#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||



















        private void Awake() 
        {
            this.cameraManager._activeCamera = this.cameraManager._mainCamera;
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






        private void Update() {
            if (Input.GetKeyDown(this.inputManager._interactionKey))
            {
                this.playerController.Move();
            }
            else if (Input.GetKeyDown(this.inputManager._secondInteractionKey))
            {
                this.playerController.Interaction();
            }
            else if (Input.GetKeyDown(this.inputManager._backKey) || Input.GetKeyDown(this.inputManager._backKey2))
            {
                this.playerController.GoToGameCamera();
            }
        }





        private void LateUpdate() {
            this.playerController.AnimationController();
        }
















        private void MouseCursorPrivate()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}