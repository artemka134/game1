using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class end_game : MonoBehaviour
{
	public GameObject end_game_obj;
	public TextMeshProUGUI end_game_text;
	public bool a = false;
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "zombie" && a == false)
		{
			end_game_obj.SetActive(true);
			end_game_text.text = "Вы проиграли! Ваш счёт составил: " + basic.score + " очков";
			a = true;
		}
	}
}
