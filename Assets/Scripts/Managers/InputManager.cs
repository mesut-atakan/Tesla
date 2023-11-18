using UnityEngine;



namespace Manager
{
    [System.Serializable]
    internal class InputManager
    {
#region ||~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~||

        [SerializeField] private KeyCode interactionKey = KeyCode.Mouse0;

        [SerializeField] private KeyCode secondInteractionKey = KeyCode.Mouse1;

        [SerializeField] private KeyCode backKey = KeyCode.Escape;
        [SerializeField] private KeyCode backKey2 = KeyCode.Backspace;

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||






#region ||~~~~~~~~|| PROPERTIES ||~~~~~~~~||

        internal KeyCode _interactionKey { get => this.interactionKey; }
        
        internal KeyCode _secondInteractionKey { get => this.secondInteractionKey; }

        internal KeyCode _backKey { get => this.backKey; }
        internal KeyCode _backKey2 { get => this.backKey2; }

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||
    }
}