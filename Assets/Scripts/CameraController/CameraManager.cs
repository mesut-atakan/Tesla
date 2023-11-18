using Manager;
using UnityEngine;



namespace CameraController
{
    internal class CameraManager : MonoBehaviour
    {

#region ||~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~||

        [Header("Classes Or Components")]

        [SerializeField] private GameManager gameManager;

        [SerializeField] private Animator changeCameraAnimator;




        [Space(10f), Header("Fields")]

        [Tooltip("Assign the Topdown Shotter camera with which the game is played here!")]
        [SerializeField] private GameObject mainCamera;
#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||




#region ||~~~~~~~~|| PROPERTIES ||~~~~~~~~||

        internal GameObject _activeCamera { get; set; } = null;

        internal GameObject _mainCamera
        {
            get => this.mainCamera;
            set => this.mainCamera = value;
        }

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||







        public enum CameraAxis
        {
            Null,
            TeslaCoil,
            Table,
            Telegraph,
            MainCamera
        }









        

        /// <summary>
        /// You can change your camera angle with this method!
        /// </summary>
        /// <param name="cameraAxis">Enter the camera angle you want to change as a parameter!</param>
        internal void ManagerCamera(CameraAxis cameraAxis)
        {
            switch (cameraAxis)
            {
                case CameraAxis.TeslaCoil:
                    this._activeCamera.SetActive(false);
                    this.gameManager._interactionTeslaCoil._camera.SetActive(true);
                    this._activeCamera = this.gameManager._interactionTeslaCoil._camera;
                    break;

                    case CameraAxis.Table:
                        this._activeCamera.SetActive(false);
                        this.gameManager._interactionTable._camera.SetActive(true);
                        this._activeCamera = this.gameManager._interactionTable._camera;
                        break;

                        case CameraAxis.Telegraph:

                            break;

                            case CameraAxis.MainCamera:
                                this._activeCamera.SetActive(false);
                                this.mainCamera.SetActive(true);
                                this._activeCamera = this.mainCamera;
                                break;
            }
        }







        /// <summary>
        /// You can run camera angle changing animation with this method!
        /// </summary>
        internal void ChangeCameraAnimation()
        {
            this.changeCameraAnimator.SetTrigger("Change");
        }
    }
}