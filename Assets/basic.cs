using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class basic : MonoBehaviour
{
	public static basic bs = new basic();
	public static float money = 100;
	public TextMeshProUGUI money_text;
	public Animator anim_money;
	public void Start()
	{
		bs.money_text = money_text;
		bs.anim_money = anim_money;
	}
	public void profit_check()
	{
		money_text.text = money.ToString();
		anim_money.SetBool("play", true);
		anim_money.Play("anim", 0, 0);
	}
	public void Stop_anim_money()
	{
		anim_money.SetBool("play", false);
	}
}
