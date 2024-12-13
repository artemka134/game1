using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class enabling_object : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Animator anim;
	public GameObject text_price;
	public Color green;
	public Color red;
	public void OnPointerEnter(PointerEventData eventData)
	{
		anim.SetBool("play", true);
		anim.Play("panel", 0, 0);
		if (basic.money >= spawn_tower.price_tower[spawn_tower.number_tower])
		{
			text_price.GetComponent<TextMeshProUGUI>().color = green;
		}
		else
		{
			text_price.GetComponent<TextMeshProUGUI>().color = red;
		}
	}
	public void OnPointerExit(PointerEventData pointerEventData)
	{
		anim.SetBool("play", false);
		anim.Play("anim_panel_closed", 0, 0);
	}
}
