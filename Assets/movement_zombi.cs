using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class movement_zombi : MonoBehaviour
{
	public float speed = 0.005f;
	public GameObject point_movement;
	public void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, point_movement.transform.position, speed);
	}
}
