using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragSystem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public Image image; // <-- 카드데이터로 수정

	Transform parentTf;

	[HideInInspector] public bool isDropped = false;

	public void OnBeginDrag(PointerEventData eventData)
	{
		parentTf = transform.parent;
		parentTf.GetComponent<BaseSlot>().SelectedItem(true);
		transform.SetParent(transform.root);
		transform.SetAsLastSibling();
		image.raycastTarget = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		transform.SetParent(parentTf);
		transform.SetAsFirstSibling();
		transform.localPosition = Vector3.zero;
		if (!isDropped)
		{
			parentTf.GetComponent<BaseSlot>().SelectedItem(false);
		}
		image.raycastTarget = true;
	}

	public void GetReset()
	{
		isDropped = false;
		parentTf.GetComponent<BaseSlot>().SelectedItem(false);
	}

}
