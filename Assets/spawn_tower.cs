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
    public int number_tower;
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
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        obj_spawn.transform.position = mousePosition;
        ob.mousePosition = mousePosition;
    }
    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.name == "объект спавна")
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
        if (mouse_spawn == true && ob.obj_spawn.GetComponent<SpriteRenderer>().sprite != null)
        {
           Instantiate(ob.object_for_spawn[number_tower], mousePosition, Quaternion.identity);
        }
    }

	public void select_an_object_town_lvl1()
	{number_tower = 0; obj_spawn.GetComponent<SpriteRenderer>().sprite = tower_textur[number_tower]; obj_spawn.GetComponent<BoxCollider2D>().size = new Vector2(3.486687f, 5.140042f);}
}