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
        this.gameManager._cameraManager.ManagerCamera(this.changeCameraAxis);
        Debug.Log($"CameraChange Info {this.changeCameraAxis}");
    }
}