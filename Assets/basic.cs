using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class basic : MonoBehaviour
{
	public static basic bs = new basic();
	public static float money = 6000000;
	public static float score = 0;
	public static List<GameObject> missle = new List<GameObject>();
	public TextMeshProUGUI money_text;
	public TextMeshProUGUI score_text;
	public Animator anim_score;
	public Animator anim_money;
	public void Start()
	{
		bs.money_text = money_text;
		bs.anim_money = anim_money;
		bs.score_text = score_text;
		bs.anim_score = anim_score;
	}
	public void profit_check()
	{
		money_text.text = money.ToString() + "$";
		anim_money.SetBool("play", true);
		anim_money.Play("anim", 0, 0);
	}
	public void score_check()
	{
		score_text.text = score.ToString();
		anim_score.SetBool("play", true);
		anim_score.Play("anim", 0, 0);
	}
}
