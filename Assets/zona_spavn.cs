using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zona_spavn : MonoBehaviour
{
	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "zombie")
		{
			collision.gameObject.GetComponent<movement_zombi>().spawn = true;
		}
	}
}
