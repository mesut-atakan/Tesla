using Manager;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;



namespace Character
{
    internal class PlayerController : MonoBehaviour
    {
#region ||~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~||

        [Header("Character Properties")]

        [SerializeField] private float characterSpeed;









        [Header("Interaction Fields")]

        [Tooltip("Enter the layers that the player can interact with!")]
        [SerializeField] private LayerMask interactionLayer;


        [Tooltip("Enter on which layer the character can move!")]
        [SerializeField] private LayerMask moveLayer;
        






        [Header("Classes Or Components")]

        [SerializeField] private NavMeshAgent ai;
        [SerializeField] private Animator animator;
        [SerializeField] private GameManager gameManager;

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||






#region ||~~~~~~~~|| PRIVATE FIELDS ||~~~~~~~~||

        // Movement Fields
        private Vector2 _mousePosition;
        private Ray _ray;
        private RaycastHit _hit;



        // Animation Controller
        private bool isMove;

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||






        internal void Move()
        {
            // Get Mouse Position
            this._mousePosition = Input.mousePosition;
            
            // Start Ray Position
            _ray = this.gameManager._topDownCamera._camera.ScreenPointToRay(this._mousePosition);

            // Is there any interaction?
            if (Physics.Raycast(this._ray, out this._hit, Mathf.Infinity, this.moveLayer))
            {
                this.ai.destination = this._hit.point;
            }
        }





        internal void AnimationController()
        {
            if (this.ai.hasPath)
            {
                if (!this.isMove)
                {
                    Debug.Log("is walk");
                    this.animator.SetTrigger("Move");
                    this.isMove = true;
                }
            }
            else
            {
                if (this.isMove)
                {
                    Debug.Log("no walk");
                    this.animator.SetTrigger("Idle");
                    this.isMove = false;
                }
            }
        }
    }
}