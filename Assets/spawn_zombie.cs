using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_zombie : MonoBehaviour
{
    public GameObject[] beginning_point = new GameObject[8];
    public GameObject[] end_point = new GameObject[13];
	public GameObject zombie, zombie2, zombie3;
    public static float time_spawn = 4f;
	public static float decreasetm = 0.028f;
	public float second;
	public static spawn_zombie sz = new spawn_zombie();
	public void Update()
	{
		second += 1 * Time.deltaTime;
		if (second >= time_spawn)
		{
			GameObject spawn_point;
			GameObject end_point;
			int point = Random.Range(0, 7);
			spawn_point = beginning_point[point];
			point = Random.Range(0, 12);
			end_point = this.end_point[point];
			int zomb = Random.Range(0, 100);
			if (time_spawn >= 3.0)
			{
				zombie.GetComponent<movement_zombi>().point_movement = end_point;
				Instantiate(zombie, spawn_point.transform.position, zombie.transform.rotation);
			}
			if (time_spawn < 3.0f && time_spawn >= 1.5f)
			{
				if (zomb <= 70)
				{
					zombie.GetComponent<movement_zombi>().point_movement = end_point;
					Instantiate(zombie, spawn_point.transform.position, zombie.transform.rotation);
				}
				if (zomb > 70)
				{
					zombie2.GetComponent<movement_zombi>().point_movement = end_point;
					Instantiate(zombie2, spawn_point.transform.position, zombie2.transform.rotation);
				}
			}
			if (time_spawn < 1.5f)
			{
				if (zomb <= 60)
				{
					zombie.GetComponent<movement_zombi>().point_movement = end_point;
					Instantiate(zombie, spawn_point.transform.position, zombie.transform.rotation);
				}
				if (zomb > 60 && zomb <= 90)
				{
					zombie2.GetComponent<movement_zombi>().point_movement = end_point;
					Instantiate(zombie2, spawn_point.transform.position, zombie2.transform.rotation);
				}
				if (zomb > 90)
				{
					zombie3.GetComponent<movement_zombi>().point_movement = end_point;
					Instantiate(zombie3, spawn_point.transform.position, zombie3.transform.rotation);
				}
			}
			second = 0;
		}
		
	}
	public static void decrease_time()
	{
		if (time_spawn >= 0.4f)
		{
			time_spawn -= decreasetm;
			decreasetm -= 0.0001f;
			//print(time_spawn);
		}
	}
}
