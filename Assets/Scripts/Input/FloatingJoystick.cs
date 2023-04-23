using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class FloatingJoystick : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
	[SerializeField] private Image AllAxis_Outline;
	[SerializeField] private Image Handle_Ridged;

	private InputMediator _mediator;
	public Vector2 InputVector => _inputVector;
	public event Action PointerDown;
	public event Action PointerUp;

	private Vector2 _inputVector;
	private Vector2 _pos;

    public void Init(InputMediator mediator) => _mediator = mediator;

    public virtual void OnPointerDown(PointerEventData ped)
	{
        OnDrag (ped);
		PointerDown.Invoke();
	}

    public virtual void OnPointerUp(PointerEventData ped)
    {
		PointerUp.Invoke();
		_inputVector = Vector2.zero;
        Handle_Ridged.rectTransform.anchoredPosition = Vector2.zero;
	}

	public virtual void OnDrag(PointerEventData ped)
	{
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(AllAxis_Outline.rectTransform,ped.position,ped.pressEventCamera, out _pos))
		{
			_pos.x /= AllAxis_Outline.rectTransform.sizeDelta.x;
			_pos.y /= AllAxis_Outline.rectTransform.sizeDelta.y;

			_inputVector = new Vector2 (_pos.x, _pos.y);
			_inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;

			Handle_Ridged.rectTransform.anchoredPosition = new Vector2(_inputVector.x*(AllAxis_Outline.rectTransform.sizeDelta.x / 2), _inputVector.y*(AllAxis_Outline.rectTransform.sizeDelta.y / 2));
		}
		_mediator.SetMoveVector(_inputVector);
	}
}