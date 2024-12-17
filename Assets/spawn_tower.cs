using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class spawn_tower : MonoBehaviour
{
    public static spawn_tower ob = new spawn_tower();

    public GameObject obj_spawn;
    public GameObject[] object_for_spawn = {};
    public static int number_tower;
    public static float[] price_tower = new float[] {10};
    public Color green; public Color red;
    Vector3 mousePosition;
    public static bool mouse_spawn = false;
    public Sprite[] tower_textur = {};

    private void Start()
    {
        ob.object_for_spawn = object_for_spawn;
        ob.obj_spawn = obj_spawn;
        ob.green = green;
        ob.red = red;
    }
    void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = -0.5f;
        obj_spawn.transform.position = mousePosition;
        ob.mousePosition = mousePosition;
        if (basic.money < price_tower[number_tower])
        { 
            coloring_obj_spawn(red);
		}
    }
    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.name == "объект спавна" && down_spawn.tower == false && basic.money >= price_tower[number_tower])
        {
            coloring_obj_spawn(green);
            mouse_spawn = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.name == "объект спавна")
        {
            coloring_obj_spawn(red);
            mouse_spawn = false;
        }
    }
    public void coloring_obj_spawn(Color color)
	{
        obj_spawn.GetComponent<SpriteRenderer>().color = color;
    }
    public void spawn_tower_mouse()
    {
        if (mouse_spawn == true && ob.obj_spawn.GetComponent<SpriteRenderer>().sprite != null && basic.money >= price_tower[number_tower])
        {
           mousePosition.z = 0;
           Instantiate(ob.object_for_spawn[number_tower], mousePosition, Quaternion.identity);
           mousePosition.z = -0.5f;
           basic.money -= price_tower[number_tower];
           basic.bs.profit_check();
        }
    }

	public void select_an_object_town_lvl1()
	{number_tower = 0; obj_spawn.GetComponent<SpriteRenderer>().sprite = tower_textur[number_tower]; obj_spawn.GetComponent<BoxCollider2D>().size = new Vector2(3.687186f, 5.140042f);}
}