using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering;

public class movement_zombi : MonoBehaviour
{
	public bool spawn = false;
	public bool live = true;
	public float speed = 0.004f;
	public float damage = 1;
	public float health;
	public float profit;
	public float bonus;
	public GameObject point_movement;
	public GameObject attack_tower = null;
	public List<GameObject> tower = new List<GameObject>();
	public Animator anim;
	public AudioSource arrival;
	public void Start()
	{
		anim = transform.gameObject.GetComponent<Animator>();
		arrival = transform.gameObject.GetComponent<AudioSource>();
	}
	public void FixedUpdate()
	{
		if (attack_tower == null)
		{
			transform.position = Vector2.MoveTowards(transform.position, point_movement.transform.position, speed);

		}
		if (attack_tower != null)
		{
			transform.position = Vector2.MoveTowards(transform.position, attack_tower.transform.position, speed);
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
			}
			}
		}
	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "tower")
		{
			if (collision.layerOverridePriority == 0)
			{
				tower.Remove(collision.gameObject);
			}
		}
	}
	public void attack()
	{
		if (attack_tower != null && live != false)
		{
			attack_tower.transform.gameObject.GetComponent<tower>().health -= damage;
			attack_tower.transform.gameObject.GetComponent<tower>().health_check();
		}
		else
		{
			
			anim.SetBool("attack", false);
		}
	}
	public void damage_received(float damage)
	{
		health -= damage;
		anim.SetBool("damage", true);
		anim.Play("damage", 1, 0);
		arrival.Play();
		if (health <= 0)
		{
			for (int i = 0; i < tower.Count; i++)
			{
				if (tower[i] != null)
				{
					tower[i].GetComponent<tower>().position_zombie.Remove(gameObject);
				}
			}
			live = false;
			anim.SetBool("dead", true);
			speed = 0;
			gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "dead_zombie";
			basic.money += profit;
			basic.score += bonus;
			basic.bs.profit_check();
			basic.bs.score_check();
			spawn_zombie.decrease_time();
		}
	}
	public void dead()
	{
		Destroy(gameObject);
	}
	public void stop_damage_anim()
	{
		anim.SetBool("damage", false);
	}
}
