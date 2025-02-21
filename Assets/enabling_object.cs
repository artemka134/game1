using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;
using System;

public class enabling_object : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Animator anim;
	public GameObject text_price;
	public Color green;
	public Color red;
	public bool boost;
	public float price;
	public void OnPointerEnter(PointerEventData eventData)
	{
		anim.SetBool("play", true);
		anim.Play("panel", 0, 0);
		if (boost != true)
		{
			if (basic.money >= price)
			{
				text_price.GetComponent<TextMeshProUGUI>().color = green;
			}
			else
			{
				text_price.GetComponent<TextMeshProUGUI>().color = red;
			}
		}
		else
		{
			if (basic.money >= 40)
			{
				text_price.GetComponent<TextMeshProUGUI>().color = green;
			}
			else
			{
				text_price.GetComponent<TextMeshProUGUI>().color = red;
			}
		}
	}
	public void OnPointerExit(PointerEventData pointerEventData)
	{
		anim.SetBool("play", false);
		anim.Play("anim_panel_closed", 0, 0);
	}
}
