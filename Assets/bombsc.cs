using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombsc : MonoBehaviour
{
    public Vector2 point_bomb;
	public float speed = 0;
	public bool explosion_b;
	public void FixedUpdate()
	{
		speed += 0.02f;
		transform.position = Vector2.MoveTowards(transform.position, point_bomb, speed * Time.deltaTime);
		if (transform.position.y == point_bomb.y)
		{
			explosion_b = true;
		}
	}
	public void OnTriggerStay2D(Collider2D collision)
	{
		if (explosion_b == true)
		{
			if (collision.gameObject.tag == "zombie")
			{
				collision.gameObject.GetComponent<movement_zombi>().damage_received(22);
			}
			Destroy(gameObject);
		}
	}
}
