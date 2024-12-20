using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down_spawn : MonoBehaviour
{
	public static bool tower;
    void OnMouseDown()
    {
        spawn_tower.ob.spawn_tower_mouse();
    }
	public void OnTriggerStay2D(Collider2D collider)
	{
		if (spawn_tower.bomb == false)
		{
			if (collider.gameObject.tag == "tower" && collider.layerOverridePriority == 1 || collider.gameObject.tag == "zombie")
			{
				spawn_tower.ob.coloring_obj_spawn(spawn_tower.ob.red);
				spawn_tower.mouse_spawn = false;
				tower = true;
			}
		}
	}
	public void OnTriggerExit2D(Collider2D collider)
	{
		if (spawn_tower.bomb == false)
		{
			if (collider.gameObject.tag == "tower" && collider.layerOverridePriority == 1 || collider.gameObject.tag == "zombie")
			{
				spawn_tower.ob.coloring_obj_spawn(spawn_tower.ob.green);
				spawn_tower.mouse_spawn = false;
				tower = false;
			}
		}
	}
}
