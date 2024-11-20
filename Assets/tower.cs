using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tower : MonoBehaviour
{
	public float second = 0;
	public List<GameObject> position_zombie = new List<GameObject>();
	public GameObject purpose;
	public GameObject missile_obj;
	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "zombie" && collision.gameObject.GetComponent<movement_zombi>().spawn == true)
		{
			position_zombie.Add(collision.gameObject);
		}
	}
	public void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "zombie" && position_zombie.Contains(other.gameObject) == false && other.gameObject.GetComponent<movement_zombi>().spawn == true)
		{
			print("Dd");
			position_zombie.Add(other.gameObject);
		}
	}
	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "zombie")
		{
			position_zombie.Remove(collision.gameObject);
		}
	}
	public void Update()
	{
		second += 1 * Time.deltaTime;
		if(second >= 3)
		{
			second = 0;
			shot();
			
		}
	}
	public void shot()
	{
		if (position_zombie.Count != 0)
		{
			for (int i = 0; i < position_zombie.Count - 1; i++)
			{
				int min = i;
				for (int j = i + 1; j < position_zombie.Count; j++)
				{
					if (Vector3.Distance(position_zombie[j].transform.position, transform.position) < Vector3.Distance(position_zombie[min].transform.position, transform.position))
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
			missile_obj.GetComponent<missile>().purpose = purpose;
		    Instantiate(missile_obj, transform.position, missile_obj.transform.rotation);
		}
	}
}
