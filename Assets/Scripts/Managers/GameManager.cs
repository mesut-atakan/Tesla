using UnityEngine;
using CameraController; // The namespace where we manage camera controls!
using Character; 


namespace Manager
{
    internal class GameManager : MonoBehaviour
    {
#region ||~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~||
        
        
        




        [Header("Script And Classes")]


        [SerializeField] private InputManager inputManager;

        [SerializeField] private PlayerController playerController;



        
        [Tooltip("Add the `Top Down Controller` class used for the Top Down Shooter perspective!")]
        [SerializeField] private TopDownCamera topDownCamera;
      
#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||








#region ||~~~~~~~~|| PRIVATE FIELDS ||~~~~~~~~||

        // ~~ Camera Mode:
        private bool _topDownMode = false;
        private bool _rotationMode = false;

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


#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||



















        private void Awake() 
        {
            this._rotationMode = true;
        }


        private void OnEnable() {
            
        }




        private void Start() {
            // MouseCursorPrivate();
        }






        private void FixedUpdate() {
            
        }






        private void Update() {
            if (Input.GetKeyDown(this.inputManager._interactionKey))
            {
                this.playerController.Move();
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