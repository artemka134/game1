using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class movement_zombi : MonoBehaviour
{
	public bool spawn = false;
	public float speed = 0.004f;
	public float damage = 1;
	public float health;
	public GameObject point_movement;
	public GameObject attack_tower = null;
	public Animator anim;

	public void Start()
	{
		anim = transform.gameObject.GetComponent<Animator>();
	}
	public void FixedUpdate()
	{
		if (attack_tower == null)
		{
			transform.position = Vector3.MoveTowards(transform.position, point_movement.transform.position, speed);

		}
		if (attack_tower != null)
		{
			transform.position = Vector3.MoveTowards(transform.position, attack_tower.transform.position, speed);
		}
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
		if (other.gameObject.tag == "tower")
		{
			if (other.layerOverridePriority == 2)
			{
				speed = 0;
				anim.SetBool("attack", true);
			}
			if (other.layerOverridePriority == 3)
			{
				attack_tower = other.gameObject;
				print("DDD");
			}
			}
		}
	public void attack()
	{
		attack_tower.transform.gameObject.GetComponent<tower>().health -= damage;
		attack_tower.transform.gameObject.GetComponent<tower>().health_check();
	}
	public void damage_received(float damage)
	{
		health -= damage;
		anim.SetBool("damage", true);

		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}
	public void stop_damage_anim()
	{
		anim.SetBool("damage", false);
	}
}
