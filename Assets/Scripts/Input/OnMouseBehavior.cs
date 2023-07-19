using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnMouseBehavior : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [Header("Mouse configurations")]
    [SerializeField] private MouseConfig MouseEnterConfig;
    [SerializeField] private MouseConfig MouseExitConfig;

    [Header("Events")]
    [SerializeField] private UnityEvent OnMouseDownEvent;
   
    public void OnPointerEnter(PointerEventData eventData)
    {
         Cursor.SetCursor(MouseEnterConfig.MouseSprite,Vector2.zero,MouseEnterConfig.CursorMode);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("On mouse Down on OnMouseDown Behavior");
        OnMouseDownEvent?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(MouseExitConfig.MouseSprite,Vector2.zero,MouseExitConfig.CursorMode);
    }
}
