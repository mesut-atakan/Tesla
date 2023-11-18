using Manager;
using UnityEngine;
using UnityEngine.Video;



namespace CameraController
{
    internal class RotationCameraController : MonoBehaviour
    {
#region ||~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~||

        [Header("Camera Properties")]

        [Tooltip("Enter the camera's rotation speed!")]
        [SerializeField, Range(0, 50)] private float rotateSpeed = 5.0f;


        [Tooltip("Enter how smoothly the camera will move!")]
        [SerializeField, Range(0, 0.2f)] private float smoothnes = 0.1f;












        [Header("Camera Distance Properties")]
        [Tooltip("Enter how far the camera should be from the pivot point with this variable!")]
        [SerializeField, Range(0, 5)] private float distance = 2;













        [Space(50f), Header("Interaction Fields")]
        
        [Tooltip("Enter which layers the player can interact with!")]
        [SerializeField] private LayerMask interactionLayer;









        [Header("Objects & Transforms")]

        [Tooltip("Assign the pivot object created for the camera to this variable!")]
        [SerializeField] private Transform pivotTransform;








        [Header("Classes Or Components")]

        [SerializeField] private GameManager gameManager;

        [SerializeField] private new Camera camera;

        

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||






#region ||~~~~~~~~|| PRIVATE FIELDS ||~~~~~~~~||

        private float mouseX, mouseY;       // The position of the mouse on the x and z axes will be transferred to these variables!


        // Raycast

        Ray _ray;
        RaycastHit _hit;

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||






#region ||~~~~~~~~|| CONSTAINS FIELDS ||~~~~~~~~||

        private const sbyte _rotationSpeedMultiply = 100;

#endregion



#region ||~~~~~~~~|| PROPTERTIES ||~~~~~~~~||

        internal Camera _camera
        {
            get => this.camera;
            set => this.camera = value;
        }

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||



















        private void Update() {
            if (Input.GetMouseButton(1))
                CameraMove();
        }







        private void OnValidate() {
            /* ~~ Variables ~~ */
            Vector3 _camPos;


            _camPos = new Vector3(this.pivotTransform.position.x - this.distance, this.camera.transform.position.y, this.pivotTransform.position.z - this.distance);
            this.camera.transform.position = _camPos;


            this.camera.transform.LookAt(this.pivotTransform.position);
        }






        internal Quaternion CameraMove()
        {
            /* ~~ Variables ~~ */
            Quaternion _targetRotation;

            this.mouseX += Input.GetAxis("Mouse X") * this.rotateSpeed;
            this.mouseY -= Input.GetAxis("Mouse Y") * this.rotateSpeed;

            // Sınırları kontrol et
            this.mouseY = Mathf.Clamp(this.mouseY, -90f, 90f);

            _targetRotation = Quaternion.Euler(this.mouseY, this.mouseX, 0f);

            Debug.Log($"Target Rotation: {this.mouseY}");

            // Dönüşü sınırla ve pürüzsüzleştir
            this.pivotTransform.rotation = Quaternion.Slerp(this.pivotTransform.rotation, _targetRotation, this.smoothnes);

            this.camera.transform.LookAt(this.pivotTransform.position);

            return this.pivotTransform.rotation;
        }




/*
        /// <summary>
        /// You can rotate your camera with this method!
        /// </summary>
        /// <returns>Instant rotation of the camera will be reversed!</returns>
        internal Quaternion CameraMove()
        {
            // ~~ Variables ~~
            Quaternion _targetRotation;


            this.mouseX += Input.GetAxis("Mouse X") * this.rotateSpeed;
            this.mouseY -= Input.GetAxis("Mouse Y") * this.rotateSpeed;


            Debug.Log($"MouseY: {mouseY}");

            
            _targetRotation = Quaternion.Euler(mouseY, mouseX, 0f);

            Debug.Log($"Target Rotation: {_targetRotation}");
            this.pivotTransform.rotation = Quaternion.Slerp(this.pivotTransform.rotation, _targetRotation, smoothnes);
            this.camera.transform.LookAt(this.pivotTransform.position);     // With this method, the camera will now constantly look at the pivot point!

            return this.pivotTransform.rotation;
        }


*/








        internal Collider InteractionObject()
        {
            // ~~ Variables ~~
            Vector2 _mousePosition;
            
            _mousePosition = Input.mousePosition;

            this._ray = this.camera.ScreenPointToRay(_mousePosition);
            if (Physics.Raycast(this._ray, out _hit, Mathf.Infinity, this.interactionLayer))
            {
                return this._hit.collider;
            }
            else
            {
                return null;
            }
        }
    }
}