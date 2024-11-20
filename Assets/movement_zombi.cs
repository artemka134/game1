using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class movement_zombi : MonoBehaviour
{
	public bool spawn = false;
	public float speed = 0.004f;
	public GameObject point_movement;
	public void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, point_movement.transform.position, speed);
		
	}
	public void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.transform.position.y < transform.position.y && collision.gameObject.tag == "zombie")
		{
			gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
		}
		if (collision.gameObject.transform.position.y > transform.position.y && collision.gameObject.tag == "zombie")
		{
			gameObject.GetComponent<SpriteRenderer>().sortingOrder = 6;
		}
	}
}
