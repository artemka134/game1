using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class movement_zombi : MonoBehaviour
{
	public bool spawn = false;
	public float speed = 0.004f;
	public float damage = 1;
	public GameObject point_movement;
	public GameObject attack_tower;
	public Animator anim;
	public void Start()
	{
		anim = transform.gameObject.GetComponent<Animator>();
	}
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
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "tower" && other.layerOverridePriority == 2)
		{
			speed = 0;
			anim.SetBool("attack", true);
			attack_tower = other.gameObject;
		}
	}
	public void attack()
	{
		attack_tower.transform.gameObject.GetComponent<tower>().health -= damage;
		attack_tower.transform.gameObject.GetComponent<tower>().health_check();
	}
}
