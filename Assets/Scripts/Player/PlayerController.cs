using Interaction;
using Manager;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;



namespace Player
{
    internal class PlayerController : MonoBehaviour
    {
#region ||~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~||



        [Header("Classes Or Components")]

        [SerializeField] private NavMeshAgent ai;
        [SerializeField] private Animator animator;
        [SerializeField] private GameManager gameManager;

        [SerializeField] private GameObject playerObject;

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||






#region ||~~~~~~~~|| PRIVATE FIELDS ||~~~~~~~~||

        // Movement Fields
        private Vector2 _mousePosition;
        private Ray _ray;
        private RaycastHit _hit;




        // Animation Controller
        private bool _anim = false;





        // Classes
        private InteractionClass _interactionClass;


#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||





#region ||~~~~~~~~|| PROPERTIES ||~~~~~~~~||

        internal bool _interactionMove { get; set; } = false;
        internal GameObject _playerObject 
        {
            get => this.playerObject;
             set => this.playerObject = value;
        }



        internal bool isMorse { get; set; } = false;

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||









#region ||~~~~~~~~|| CONSTAINS FIELDS ||~~~~~~~~||
        internal bool _isMove { get; set; } = true;


        internal const string moveLayerName = "Move";
        internal const string interactionLayerName = "Interaction";

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||




















        /// <summary>
        /// With this method you can move the player!
        /// </summary>
        internal void Move()
        {
            if (CreateRay(moveLayerName) && this._isMove)
            {
                
                    Debug.Log("MOVE");
                    this.ai.destination = this._hit.point;
                
            }
        }


        /// <summary>
        /// You can interact with objects with this method!
        /// </summary>
        internal void Interaction()
        {
            if (CreateRay(interactionLayerName) && this._isMove)
            {
                this._interactionClass = _hit.collider.GetComponent<InteractionClass>();

                this.ai.destination = this._interactionClass._objectInteractionTransform.position;

                this._interactionMove = true;

                this.gameManager._events.changeCameraAxis = this._interactionClass._cameraAxis;
            }
        }
        





        /// <summary>
        /// You can create a new raycast with this function!
        /// </summary>
        /// <param name="layerMask">Enter which layers you want the raycast to ignore!</param>
        /// <returns>Eger ray bir obje ile temas ediyorsa true etmiyorsa false degerlerini geri donderecek!</returns>
        private bool CreateRay(string layerName)
        {
            this._mousePosition = Input.mousePosition;
            this._ray = this.gameManager._topDownCamera._camera.ScreenPointToRay(_mousePosition);

            if (Physics.Raycast(_ray, out this._hit, Mathf.Infinity) && this._hit.collider.gameObject.layer == LayerMask.NameToLayer(layerName))
            {
                Debug.DrawRay(_ray.origin, _hit.point, Color.yellow, 2.0f);
                Debug.Log($"Hit Info: {this._hit.collider.name}");
                return true;
            }
            else
            {
                Debug.DrawRay(_ray.origin, this.gameManager._topDownCamera._camera.transform.forward, Color.red, 1.0f);
                return false;
            }
        }













        /// <summary>
        /// With this method you can control the animations of the character!
        /// </summary>
        internal void AnimationController()
        {
            if (this.ai.hasPath)
            {
                if (!this._anim)
                {
                    this.animator.SetTrigger("Move");
                    _anim = true;
                }
            }
            else
            {
                if (this._anim)
                {
                    this.animator.SetTrigger("Idle");
                    _anim = false;
                }
            }
        }





        internal bool InteractionAreaControl()
        {
            if (Vector3.Distance(this.ai.gameObject.transform.position, this._interactionClass._objectInteractionTransform.position) < 1.0f)
            {
                this._interactionMove = false;
                this.gameManager._cameraManager.ChangeCameraAnimation();
                this._interactionClass = null;
                return true;
            }
            else
            {
                return false;
            }
        }







        internal void GoToGameCamera()
        {
            if (this.gameManager._cameraManager._gameCamera == false)
            {
                this.gameManager._events.changeCameraAxis = CameraController.CameraManager.CameraAxis.MainCamera;
                this.gameManager._cameraManager.GoToGameCameraAxisAnimation();
            }
        }
    }
}