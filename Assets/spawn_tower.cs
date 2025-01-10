using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class spawn_tower : MonoBehaviour
{
    public static spawn_tower ob = new spawn_tower();

    public GameObject obj_spawn;
    public GameObject[] object_for_spawn = {};
    public Image bomb_img;
    public static int number_tower;
    public static float[] price_tower = new float[] {10, 100};
    public static float time_bomb = 10;
    public Color green, red;
    public Color green_bomb, red_bomb;
    Vector3 mousePosition;
    public Vector2 spawn_bomb;
    public static bool mouse_spawn = false;
    public static bool bomb = false;
	public static bool bomb_time = false;
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
            obj_spawn.GetComponent<SpriteRenderer>().sprite = null;
            bomb = false;
		}
        if (bomb_time == false && time_bomb > 0)
        {
            time_bomb -= 1 * Time.deltaTime;
			bomb_img.fillAmount = time_bomb / 10;
		}
        if (mouse_spawn == false)
		{
            if (bomb == true && time_bomb >= 0)
            {
                coloring_obj_spawn(red_bomb);
            }
            else
			{
                coloring_obj_spawn(red);
            }
		}
        else if (mouse_spawn == true)
        {
			if (bomb == true && time_bomb <= 0)
			{
				coloring_obj_spawn(green_bomb);
			}
			else
			{
				coloring_obj_spawn(green);
			}
		}
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = -0.5f;
        obj_spawn.transform.position = mousePosition;
        ob.mousePosition = mousePosition;
        if (basic.money < price_tower[number_tower] || time_bomb > 0)
        {
            if (bomb == false && basic.money < price_tower[number_tower])
            {
                coloring_obj_spawn(red);
            }
            if (basic.money < price_tower[number_tower] || time_bomb > 0 && bomb == true)
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
                mouse_spawn = true;
            }
            if (bomb == true && time_bomb <= 0)
            {
                mouse_spawn = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.name == "объект спавна")
        {
            mouse_spawn = false;
        }
    }
    public void coloring_obj_spawn(Color color)
	{
        obj_spawn.GetComponent<SpriteRenderer>().color = color;
    }
    public void spawn_tower_mouse()
    {
        if (mouse_spawn == true && ob.obj_spawn.GetComponent<SpriteRenderer>().sprite != null && basic.money >= price_tower[number_tower] && down_spawn.tower == false)
        {
           mousePosition.z = 0;
            if (bomb == false)
            {
                Instantiate(ob.object_for_spawn[number_tower], mousePosition, Quaternion.identity);
            }
			if (time_bomb <= 0 && bomb == true)
			{
                Vector2 vec = new Vector2(mousePosition.x, 5.5f);
                ob.object_for_spawn[number_tower].GetComponent<bombsc>().point_bomb = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(ob.object_for_spawn[number_tower], vec, Quaternion.identity);
                time_bomb = 10;
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