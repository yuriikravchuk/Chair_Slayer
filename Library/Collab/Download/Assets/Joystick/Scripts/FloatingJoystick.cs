using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FloatingJoystick : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
	private Image AllAxis_Outline;
	[SerializeField]
	private Image Handle_Ridged;
	private Vector2 inputVector;
    private Vector2 pos;
    private Character character;

    private void Start()
    {
        AllAxis_Outline = GetComponent<Image>();
        Handle_Ridged = transform.GetChild(0).GetComponent<Image>();
    }

    void FixedUpdate()
    {
        if (character)
        {
            Horizontal();
            Vertical();
        }
    }
	public virtual void OnPointerDown(PointerEventData ped)
	{
        if (!character)
            character = MapController.Instance.ch_Character;
        OnDrag (ped);
        character.anim.SetBool("move", true);
	}

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        Handle_Ridged.rectTransform.anchoredPosition = Vector2.zero;
        character.anim.SetBool("move", false);
    }
	public virtual void OnDrag(PointerEventData ped)
	{

		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(AllAxis_Outline.rectTransform,ped.position,ped.pressEventCamera, out pos))
		{
			pos.x = (pos.x / AllAxis_Outline.rectTransform.sizeDelta.x);
			pos.y = (pos.y / AllAxis_Outline.rectTransform.sizeDelta.y);

			inputVector = new Vector2 (pos.x, pos.y);
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

			Handle_Ridged.rectTransform.anchoredPosition = new Vector2(inputVector.x*(AllAxis_Outline.rectTransform.sizeDelta.x / 2), inputVector.y*(AllAxis_Outline.rectTransform.sizeDelta.y / 2));
		}
	}
	
	public void Horizontal()
	{
        if (Input.GetAxis("Horizontal") != 0)
        {
            inputVector.x = Input.GetAxis("Horizontal");
            character.anim.SetBool("move", true);
        }
        else if(inputVector.x == 0)
        {
            character.anim.SetBool("move", false);
        }
			character.horizontal = inputVector.x;
	}

	public void Vertical()
	{
        if(Input.GetAxis("Horizontal") != 0)
        {
            inputVector.y = Input.GetAxis("Vertical");
            character.anim.SetBool("move", true);
        }
        else if (inputVector.y == 0)
        {
            character.anim.SetBool("move", false);
        }
        character.vertical = inputVector.y;	
	}
}