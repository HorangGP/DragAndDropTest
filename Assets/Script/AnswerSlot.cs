using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnswerSlot : MonoBehaviour, IDropHandler
{
	[SerializeField] GameObject regiImg;
	[SerializeField] GameObject resetBtn;
	[SerializeField] Image image;

	[SerializeField] DragSystem dragSystem;

	[HideInInspector] public bool fullSlot = false;

	public void OnDrop(PointerEventData eventData)
	{
		GameObject dropped = eventData.pointerDrag;

		if (!fullSlot)
		{
			if (dropped.GetComponent<DragSystem>() != null)
			{
				dragSystem = dropped.GetComponent<DragSystem>();
				image.sprite = dragSystem.image.sprite;
				dragSystem.isDropped = true;

				IsDropped(true);
			}
			else
			{
				return;
			}
		}
		else
		{
			if (dropped.GetComponent<AnswerDrag>() != null)
			{
				AnswerDrag answerDrag = dropped.GetComponent<AnswerDrag>();
				answerDrag.OutBoxCheck(false);
			}
			else
			{
				return;
			}
		}
	}

	void IsDropped(bool isDropped)
	{
		fullSlot = isDropped;
		resetBtn.SetActive(isDropped);
		regiImg.SetActive(isDropped);
	}

	public void OnReset()
	{
		dragSystem.GetReset();
		fullSlot = false;
		dragSystem = null;
		image.sprite = null;
		IsDropped(false);
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
