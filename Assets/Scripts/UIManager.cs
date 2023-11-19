using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;



internal class UIManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
#region ||~~~~~~~~|| private Fields ||~~~~~~~~||

    internal bool mouseUI;

#endregion ||~~~~~~~~|| XXXX ||~~~~~~~~||




    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseUI = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseUI = false;
    }
}