using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnswerDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public Image image;

	Transform parentTf;

	bool draggable;

	public void OnBeginDrag(PointerEventData eventData)
	{
		GameObject draggedItem = eventData.pointerDrag;

		parentTf = transform.parent;
		draggable = parentTf.GetComponent<AnswerSlot>().fullSlot;
		if (draggable)
		{
			transform.SetParent(transform.root);
			transform.SetAsLastSibling();
		}
		image.raycastTarget = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (draggable)
		{
			transform.position = Input.mousePosition;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (draggable)
		{
			transform.SetParent(parentTf);
			transform.SetAsFirstSibling();
			transform.localPosition = Vector3.zero;

			GameObject endDragged = eventData.pointerEnter;

			if (endDragged != parentTf.gameObject)
			{
				OutBoxCheck(true);
			}
		}
		image.raycastTarget = true;
	}

	public void OutBoxCheck(bool check)
	{
		if (check)
		{
			parentTf.GetComponent<AnswerSlot>().OnReset();
		}
		else
		{
			return;
		}
	}
}
