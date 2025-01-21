using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_shot : MonoBehaviour
{
	public Animator anim;
	public GameObject purpose;
	public GameObject missile_obj;

	public void Start()
	{
		anim = gameObject.GetComponent<Animator>();
	}
	public void shot_cannon()
	{
		gameObject.transform.parent.GetComponent<tower>().shot();
		missile_obj.GetComponent<missile>().purpose = purpose.transform.position;
		missile_obj.GetComponent<missile>().obj_attack = purpose;
		Instantiate(missile_obj, transform.position, missile_obj.transform.rotation);
	}
	public void end_shot()
	{
		anim.SetBool("shot", false);
	}
}
