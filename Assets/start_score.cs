using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using YG;

public class start_score : MonoBehaviour
{
    public TextMeshProUGUI text;

	public void Start()
	{
		text.text = "��� ������: " + YG2.saves.score.ToString("0") + " �����";
		
	}
}
