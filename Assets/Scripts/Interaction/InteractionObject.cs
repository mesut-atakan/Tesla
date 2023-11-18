using CameraController;
using UnityEngine;



namespace Interaction
{
    internal abstract class InteractionClass : MonoBehaviour
    {
#region ||~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~||

        [Header("Interaction Object Fields")]


        [Tooltip("What position should the character reach when the character interacts with this object?")]
        [SerializeField] protected Transform objectInteractionTransform;


        [Tooltip("If clicking on this object will switch to the FPS Viewpoint, add a camera component here!")]
        [SerializeField] protected new GameObject camera;


        [SerializeField] protected CameraManager.CameraAxis cameraAxis;
        






        



#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||



#region ||~~~~~~~~|| PRIVATE FIELDS ||~~~~~~~~||


#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||





#region ||~~~~~~~~|| PROPERTIES ||~~~~~~~~||

        internal Transform _objectInteractionTransform { get => this.objectInteractionTransform; }
        
        internal CameraManager.CameraAxis _cameraAxis { get => this.cameraAxis; }

        internal GameObject _camera 
        {
            get => this.camera;
            set => this.camera = value;
        }
        

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||





    }

}