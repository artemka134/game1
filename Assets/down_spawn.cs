using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down_spawn : MonoBehaviour
{
    void OnMouseDown()
    {
        spawn_tower.ob.spawn_tower_mouse();
    }
	public void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "tower")
		{
			spawn_tower.ob.coloring_obj_spawn(spawn_tower.ob.red);
			spawn_tower.mouse_spawn = false;
		}
	}
	public void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "tower")
		{
			spawn_tower.ob.coloring_obj_spawn(spawn_tower.ob.red);
			spawn_tower.mouse_spawn = false;
		}
	}
}
