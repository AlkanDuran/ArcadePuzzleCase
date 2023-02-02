using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickMonitor : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Image MonitorItem;
    private RectTransform Handle;
    [SerializeField] private float HandleMaxMove = 130f;
    public float GetHorizontal => SimpleInput.GetAxis("Horizontal");
    public float GetVertical => SimpleInput.GetAxis("Vertical");
   
    public void OnPointerDown(PointerEventData eventData)
    {
        Handle.transform.position = eventData.pressPosition;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Handle.transform.localPosition =Vector3.zero;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Handle.transform.position = eventData.position;
        if (Handle.transform.localPosition.magnitude > HandleMaxMove)
        {
            Handle.transform.localPosition = Handle.transform.localPosition.normalized * HandleMaxMove;
        }
    }
}