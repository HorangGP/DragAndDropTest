using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSlot : MonoBehaviour
{
	[SerializeField] GameObject fadeImg;

	public void SelectedItem(bool isSelected)
	{
		fadeImg.SetActive(isSelected);
	}
}
