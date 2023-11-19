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
        [SerializeField] private Animator changeCameraAnimator2;




        [Space(10f), Header("Fields")]

        [Tooltip("Assign the Topdown Shotter camera with which the game is played here!")]
        [SerializeField] private Camera mainCamera;
#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||




#region ||~~~~~~~~|| PROPERTIES ||~~~~~~~~||

        internal Camera _activeCamera { get; set; } = null;

        internal bool _gameCamera { get; set; } = true;

        internal Camera _mainCamera
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
            Cabels,
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
                    this._activeCamera.gameObject.SetActive(false);
                    this.gameManager._interactionTeslaCoil._camera.gameObject.SetActive(true);
                    this._activeCamera = this.gameManager._interactionTeslaCoil._camera;
                    this.gameManager._itemInteraction._camera = this._activeCamera;
                    break;

                    case CameraAxis.Table:
                        this._activeCamera.gameObject.SetActive(false);
                        this.gameManager._interactionTable._camera.gameObject.SetActive(true);
                        this._activeCamera = this.gameManager._interactionTable._camera;
                        this.gameManager._itemInteraction._camera = this._activeCamera;
                        break;

                        case CameraAxis.Telegraph:

                            break;

                            case CameraAxis.Cabels:
                                this._activeCamera.gameObject.SetActive(false);
                                this.gameManager._interactionCable._camera.gameObject.SetActive(true);
                                this._activeCamera = this.gameManager._interactionCable._camera;
                                this.gameManager._itemInteraction._camera = this._activeCamera;
                                break;

                                case CameraAxis.MainCamera:
                                    this._activeCamera.gameObject.SetActive(false);
                                    this.mainCamera.gameObject.SetActive(true);
                                    this._activeCamera = this.mainCamera;
                                    this.gameManager._itemInteraction._camera = null;
                                    break;
            }
        }







        /// <summary>
        /// You can run camera angle changing animation with this method!
        /// </summary>
        internal void ChangeCameraAnimation()
        {
            this.changeCameraAnimator.SetTrigger("Change");
            this.changeCameraAnimator2.SetTrigger("Change");
        }

        /// <summary>
        /// With this method, you can switch to the main camera of the game!
        /// </summary>
        internal void GoToGameCameraAxisAnimation()
        {
            this.changeCameraAnimator.SetTrigger("ExitChange");
            this.changeCameraAnimator2.SetTrigger("ExitChange");
        }
    }
}