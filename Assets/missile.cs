using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class missile : MonoBehaviour
{
	public float damage_missile;
    public Vector2 purpose;
	public GameObject obj_attack;
	public void Start()
	{
		basic.missle.Add(gameObject);
		Vector2 targ = purpose;

		Vector2 objectPos = transform.position;
		targ.x = targ.x - objectPos.x;
		targ.y = targ.y - objectPos.y;

		float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

	}
	public void FixedUpdate()
	{
		transform.position = Vector2.MoveTowards(transform.position, purpose, 10.5f * Time.deltaTime);
		if (Vector2.Distance(transform.position, purpose) == 0)
		{
			Destroy(gameObject);
			basic.missle.Remove(gameObject);
		}
	}
	public void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject == obj_attack)
		{
			if (collision.gameObject.GetComponent<movement_zombi>().live == true)
			{
				collision.gameObject.GetComponent<movement_zombi>().damage_received(damage_missile);
				basic.missle.Remove(gameObject);
				Destroy(gameObject);
			}
			}
		}
}
