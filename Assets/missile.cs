using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class missile : MonoBehaviour
{
	public float damage_missile;
    public Vector3 purpose;
	public GameObject obj_attack;
	public void Start()
	{
		Vector3 targ = purpose;
		targ.z = 0f;

		Vector3 objectPos = transform.position;
		targ.x = targ.x - objectPos.x;
		targ.y = targ.y - objectPos.y;

		float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
	public void FixedUpdate()
	{
		transform.position = Vector3.MoveTowards(transform.position, purpose, 0.18f);
	}
	public void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject == obj_attack)
		{
			collision.gameObject.GetComponent<movement_zombi>().damage_received(damage_missile);
			Destroy(gameObject);
		}
	}
}
