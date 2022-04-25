using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{ 
    public Animator animator = null;
    
    public virtual void OnPointerDown(PointerEventData ped)
    {
        SetAnimator();
        animator.SetBool("aiming", true);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {    
        animator.SetBool("aiming", false);
    }
    void SetAnimator()
    {
        if(!animator)
        animator = MapController.Instance.ch_Character.GetComponent<Animator>();
    }
}
    
   

