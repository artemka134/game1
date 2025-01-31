using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class basic : MonoBehaviour
{
	public static basic bs = new basic();
	public static float money = 70;
	public static float score = 0;
	public static float time_boost = 10;
	public static float boost_time = 30;
	public static bool boost = false;
	public static List<GameObject> missle = new List<GameObject>();
	public static List<GameObject> tower = new List<GameObject>();
	public Image boost_img, boost_img2;
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
		bs.money_text.text = money.ToString("0")+"$";
	}
	public void Update()
	{
		if (time_boost > 0 && boost == false)
		{
			time_boost -= 1 * Time.deltaTime;
			boost_img.fillAmount = time_boost / 10;
		}
		if (boost_time > 0 && boost == true)
		{
			boost_time -= 1 * Time.deltaTime;
			boost_img2.fillAmount = boost_time / 30;
		}
		if (boost_time <= 0 && boost == true)
		{
			boost_time = 30;
			time_boost = 10;
			boost = false;
			for (int i = 0; i < tower.Count; i++)
			{
				tower[i].GetComponent<tower>().recharge *= 2;
			}
		}
	}
	public void profit_check()
	{
		money_text.text = money.ToString("0") + "$";
		anim_money.SetBool("play", true);
		anim_money.Play("anim", 0, 0);
	}
	public void score_check()
	{
		score_text.text = score.ToString();
		anim_score.SetBool("play", true);
		anim_score.Play("anim", 0, 0);
	}
	public void boost_void()
	{
		if (money >= 1000 && time_boost <= 0)
		{
			money -= 1000;
			boost = true;
			for (int i = 0; i < tower.Count; i++)
			{
				tower[i].GetComponent<tower>().recharge *= 0.5f;
			}
		}
	}
}
