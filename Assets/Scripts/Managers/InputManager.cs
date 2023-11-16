using UnityEngine;



namespace Manager
{
    [System.Serializable]
    internal class InputManager
    {
#region ||~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~||

        [SerializeField] private KeyCode interactionKey = KeyCode.Mouse0;

        [SerializeField] private KeyCode secondInteractionKey = KeyCode.Mouse1;

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||






#region ||~~~~~~~~|| PROPERTIES ||~~~~~~~~||

        internal KeyCode _interactionKey { get => this.interactionKey; }
        
        internal KeyCode _secondInteractionKey { get => this.secondInteractionKey; }

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||
    }
}