using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TriggerMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("Events")]
    public UnityEvent onPointerDown;
    public UnityEvent onPointerEnter;
    public UnityEvent onPointerExit;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (onPointerDown != null)
            onPointerDown.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (onPointerEnter != null) 
            onPointerEnter.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(onPointerExit != null)
            onPointerExit.Invoke();
    }
}
