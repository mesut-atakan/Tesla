using CameraController;
using Manager;
using UnityEngine;



internal class Events : MonoBehaviour
{

#region ||~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~||

    [SerializeField] private GameManager gameManager;

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||






#region ||~~~~~~~~|| PROPERTIES ||~~~~~~~~||

    internal CameraManager.CameraAxis changeCameraAxis { get; set; }

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||






    /// <summary>
    /// By adding this method to the animation parameter, you can switch to any camera angle you want!
    /// </summary>
    public void ChangeToCamera()
    {
        if (this.changeCameraAxis == CameraManager.CameraAxis.MainCamera)
            this.gameManager._cameraManager._gameCamera = true;
        else
            this.gameManager._cameraManager._gameCamera = false;

        this.gameManager._cameraManager.ManagerCamera(this.changeCameraAxis);
        this.changeCameraAxis = CameraManager.CameraAxis.Null; 
        Debug.Log($"CameraChange Info {this.changeCameraAxis}");
    }
}