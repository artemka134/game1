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
    public static float[] price_tower = new float[] {10, 100};
    public Color green, red;
    public Color green_bomb, red_bomb;
    Vector3 mousePosition;
    public Vector2 spawn_bomb;
    public static bool mouse_spawn = false;
    public static bool bomb = false;
    public Sprite[] tower_textur;

    private void Start()
    {
        ob.object_for_spawn = object_for_spawn;
        ob.obj_spawn = obj_spawn;
        ob.green = green;
        ob.red = red;
        ob.green_bomb = green_bomb;
        ob.red_bomb = red_bomb;
    }
    void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = -0.5f;
        obj_spawn.transform.position = mousePosition;
        ob.mousePosition = mousePosition;
        if (basic.money < price_tower[number_tower])
        {
            if (bomb == false)
            {
                coloring_obj_spawn(red);
            }
            else
			{
                coloring_obj_spawn(red_bomb);
			}
		}
    }
    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.name == "объект спавна" && basic.money >= price_tower[number_tower])
        {
            if (down_spawn.tower == false && bomb == false)
            {
                coloring_obj_spawn(green);
            }
            if (bomb == true)
            {
                coloring_obj_spawn(green_bomb);
            }
            mouse_spawn = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.name == "объект спавна")
        {
            if (bomb == false)
            {
                coloring_obj_spawn(red);
            }
            else
			{
                coloring_obj_spawn(red_bomb);
            }
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
            if (bomb == false)
            {
                Instantiate(ob.object_for_spawn[number_tower], mousePosition, Quaternion.identity);
            }
			else
			{
                Vector2 vec = new Vector2(mousePosition.x, 5.12f);
                ob.object_for_spawn[number_tower].GetComponent<bombsc>().point_bomb = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(ob.object_for_spawn[number_tower], vec, Quaternion.identity);
            }
           mousePosition.z = -0.5f;
           basic.money -= price_tower[number_tower];
           basic.bs.profit_check();
        }
    }

	public void select_an_object_town_lvl1()
	{
        number_tower = 0;
        obj_spawn.GetComponent<SpriteRenderer>().sprite = tower_textur[number_tower];
        obj_spawn.GetComponent<BoxCollider2D>().size = new Vector2(3.687186f, 5.140042f);
        obj_spawn.transform.localScale = new Vector3(0.358511418f, 0.349489331f, 1);
        bomb = false;
    }
    public void select_an_object_bomb()
	{
        number_tower = 1;
        obj_spawn.GetComponent<SpriteRenderer>().sprite = tower_textur[number_tower];
        obj_spawn.GetComponent<BoxCollider2D>().size = new Vector2(1.026046f, 1.026165f);
        obj_spawn.transform.localScale = new Vector3(3.45649648f, 1.98367476f, 1);
        bomb = true;
    }
}