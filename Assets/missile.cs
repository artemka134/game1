using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class missile : MonoBehaviour
{
    public GameObject purpose;
	public void Start()
	{
		Vector3 targ = purpose.transform.position;
		targ.z = 0f;

		Vector3 objectPos = transform.position;
		targ.x = targ.x - objectPos.x;
		targ.y = targ.y - objectPos.y;

		float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
	public void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, purpose.transform.position, 0.2f);
	}
	public void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject == purpose)
		{
			Destroy(gameObject);
		}
	}
}
