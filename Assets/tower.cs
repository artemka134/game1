using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;


public class tower : MonoBehaviour
{
	public float max_health = 100;
	public float health = 100;
	public float second = 0;
	public float recharge;
	public List<GameObject> position_zombie = new List<GameObject>();
	public GameObject purpose;
	public GameObject missile_obj;
	//public void OnTriggerEnter2D(Collider2D collision)
	//{
	//	if (collision.gameObject.tag == "zombie" && collision.gameObject.GetComponent<movement_zombi>().spawn == true)
	//	{
	//		position_zombie.Add(collision.gameObject);
	//	}
	//}
	public void Start()
	{
		transform.Find("Canvas/Image/текст").gameObject.GetComponent<TextMeshProUGUI>().text = health + "/" + max_health;
		transform.Find("Canvas/Image").gameObject.GetComponent<Image>().fillAmount = health / max_health;
	}
	public void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "zombie" && position_zombie.Contains(other.gameObject) == false && other.gameObject.GetComponent<movement_zombi>().spawn == true)
		{
			position_zombie.Add(other.gameObject);
		}
		if (other.gameObject.tag == "zombie" && other.gameObject.GetComponent<movement_zombi>().tower.Contains(gameObject) && other.gameObject.GetComponent<movement_zombi>().spawn == true)
		{
			other.gameObject.GetComponent<movement_zombi>().tower.Add(gameObject);
		}
	}
	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "zombie")
		{
			position_zombie.Remove(collision.gameObject);
		}
	}
	public void OnMouseDown()
	{
		
	}
	public void Update()
	{
		second += 1 * Time.deltaTime;
		if (second >= recharge)
		{
			second = 0;
			shot();

		}
	}
	public void health_check()
	{
		transform.Find("Canvas/Image/текст").gameObject.GetComponent<TextMeshProUGUI>().text = health + "/" + max_health;
		transform.Find("Canvas/Image").gameObject.GetComponent<Image>().fillAmount = health / max_health;
		if (health <= 0)
		{
			for (int i = 0; i < position_zombie.Count; i++)
			{
				if (position_zombie[i].GetComponent<movement_zombi>().attack_tower == gameObject)
				{
					position_zombie[i].GetComponent<movement_zombi>().attack_tower = null;
					position_zombie[i].GetComponent<Animator>().SetBool("attack", false);
					position_zombie[i].GetComponent<movement_zombi>().speed = 0.005f;
				}
				print(position_zombie[i]);
			}
			Destroy(gameObject);
		}
	}
	public void shot()
	{
		if (position_zombie.Count != 0)
		{
			for (int i = 0; i < position_zombie.Count; i++)
			{
				if (position_zombie[i] == null)
				{
					position_zombie.Remove(position_zombie[i]);
				}
			}
			for (int i = 0; i < position_zombie.Count - 1; i++)
			{

				int min = i;
				for (int j = i + 1; j < position_zombie.Count; j++)
				{
					if (Vector2.Distance(position_zombie[j].transform.position, transform.position) < Vector2.Distance(position_zombie[min].transform.position, transform.position))
					{
						min = j;
					}
				}
				GameObject dummy = position_zombie[i];
				position_zombie[i] = position_zombie[min];
				position_zombie[min] = dummy;
				min = i;
			}
			purpose = position_zombie[0];
			missile_obj.GetComponent<missile>().purpose = purpose.transform.position;
			missile_obj.GetComponent<missile>().obj_attack = purpose;
			Instantiate(missile_obj, transform.position, missile_obj.transform.rotation);
		}
	}
}
