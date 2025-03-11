using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class start_score : MonoBehaviour
{
    public TextMeshProUGUI text;

	public void Start()
	{
		text.text = "Build an object: " + PlayerPrefs.GetFloat("score");	
	}
}
