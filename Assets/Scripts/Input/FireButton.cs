using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class FireButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public UnityEvent PointerDown;
    public UnityEvent PointerUp;

    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.Space))
    //        PointerDown.Invoke();
    //    else
    //        PointerUp.Invoke();
    //}
    public virtual void OnPointerDown(PointerEventData ped)
    {
        PointerDown.Invoke();
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        PointerUp.Invoke();
    }
}