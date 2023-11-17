using Manager;
using UnityEngine;


namespace CameraController
{
    internal class TopDownCamera : MonoBehaviour
    {
    #region ||~~~~~~~~~~~~~||||~~~~~~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~~~~~~||||~~~~~~~~~~~~~||

        [Header("Camera Movement Properties")]

        [Tooltip("Camaera Move Speed")]
        [SerializeField] [Range(0.0001f, 0.050f)] private float cameraMoveSmoothness = 0.05f;


        [Tooltip("Mark the axes you want to restrict position movement!")]
        [SerializeField] private PositionConstrains positionConstrains;





        

        [Space(30f), Header("Distance Properties")]

        [Tooltip("Enter the distance between the left and right axis of the camera!")]
        [SerializeField] [Range(-25, 25)] private float XAxisDistance;


        [Tooltip("Enter the distance of the camera from the ground! (Y Axis Distance!)")]
        [SerializeField] [Range(-25, 25)] private float YAxisDistance;


        [Tooltip("Enter the distance relative to the character's back! (Z Axis Distance!)")]
        [SerializeField] [Range(-25,25)] private float ZAxisDistance;









        [Space(30f), Header("Scripts Or Components")]

        [SerializeField] private GameManager gameManager;
        [SerializeField] private new Camera camera;


        









        [Space(30f), Header("Target Properties")]

        [Tooltip("Enter the object to be tracked!")]
        [SerializeField] private Transform targetTransform;

    #endregion ||~~~~~~~~~~~~~||||~~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~~||||~~~~~~~~~~~~~||





    #region ||~~~~~~~~~~~~~||||~~~~~~~~~~~~~|| PRIVATE FIELDS ||~~~~~~~~~~~~~||||~~~~~~~~~~~~~||

        private float _targetXAxis;
        private float _targetYAxis;
        private float _targetZAxis;

    #endregion ||~~~~~~~~~~~~~||||~~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~~||||~~~~~~~~~~~~~||







    #region ||~~~~~~~~~~~~~||||~~~~~~~~~~~~~|| SERIALIZABLE ||~~~~~~~~~~~~~||||~~~~~~~~~~~~~||

        [System.Serializable]
        private struct PositionConstrains
        {
            [SerializeField] internal bool xAxis;
            [SerializeField] internal bool yAxis;
            [SerializeField] internal bool zAxis;
        }

    #endregion










    #region ||~~~~~~~~~~~~~||||~~~~~~~~~~~~~|| PROPERTIES ||~~~~~~~~~~~~~||||~~~~~~~~~~~~~||

        internal Transform _targetTransform
        {
            get => this.targetTransform; 
            set => this.targetTransform = value;  
        }


        internal Camera _camera
        {
            get => this.camera;
            set => this.camera = value;
        }

    #endregion  ||~~~~~~~~~~~~~||||~~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~~||||~~~~~~~~~~~~~||


        

        private void OnValidate() {
            PositionConstrainsIfElse();
            this.camera.transform.position = new Vector3(this._targetXAxis, this._targetYAxis, this._targetZAxis);
        }




        internal void CameraMovement()
        {
            PositionConstrainsIfElse();
            this.camera.transform.position = Vector3.Lerp(this.camera.transform.position, new Vector3(this._targetXAxis, this._targetYAxis, this._targetZAxis), cameraMoveSmoothness);
        }




        internal void PositionConstrainsIfElse()
        {
            if (!this.positionConstrains.xAxis)
                this._targetXAxis = this.targetTransform.position.x + this.XAxisDistance;
            else
                this._targetXAxis = this.XAxisDistance;
            
            if (!this.positionConstrains.yAxis)
                this._targetYAxis = this.targetTransform.position.y + this.YAxisDistance;
            else
                this._targetYAxis = this.YAxisDistance;

            if (!this.positionConstrains.zAxis)
                this._targetZAxis = this.targetTransform.position.z + this.ZAxisDistance;
            else
                this._targetZAxis = this.ZAxisDistance;
        }

    }
    
}