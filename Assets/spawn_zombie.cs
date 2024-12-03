using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_zombie : MonoBehaviour
{
    public GameObject[] beginning_point = new GameObject[8];
    public GameObject[] end_point = new GameObject[13];
	public GameObject zombie;
    public float time_spawn = 1;
	public float second;
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
			zombie.GetComponent<movement_zombi>().point_movement = end_point;
			Instantiate(zombie, spawn_point.transform.position, zombie.transform.rotation);
			second = 0;
		}
	}
}
