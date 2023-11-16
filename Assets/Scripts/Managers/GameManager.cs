using UnityEngine;
using CameraController; // The namespace where we manage camera controls!


namespace Manager
{
    internal class GameManager : MonoBehaviour
    {
#region ||~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~||
        [SerializeField] private InputManager inputManager;
        
        
        
        [Header("Script And Classes")]
        
        [Tooltip("Class to run to have a player machine perspective!")]
        [SerializeField] private RotationCameraController rotationCameraController;
#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||








#region ||~~~~~~~~|| PRIVATE FIELDS ||~~~~~~~~||

        // ~~ Camera Mode:
        private bool _topDownMode = false;
        private bool _rotationMode = false;

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||






#region ||~~~~~~~~|| PROPERTIES ||~~~~~~~~||

        internal InputManager _inputManager { get => this.inputManager; }


#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||



















        private void Awake() 
        {
            this.rotationCameraController._camera = Camera.main;

            this._rotationMode = true;
        }


        private void OnEnable() {
            
        }




        private void Start() {
            
        }






        private void FixedUpdate() {
            
        }






        private void Update() {
            
        }





        private void LateUpdate() {
            /* ~~ Camera Controller ~~ */
            if (this._rotationMode && Input.GetKey(this.inputManager._secondInteractionKey))      // If the camera mode is in 'rotation' mode and the 'secondInteractionKey' button is pressed
            {
                this.rotationCameraController.CameraMove();     // The camera is in rotation mode and the camera will be rotated!
            }
        }
    }
}