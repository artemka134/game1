using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_tower : MonoBehaviour
{
    public GameObject obj_spawn;

    //создание объектов класса town
    public static tower tower_lvl1 = new tower();
    public Sprite tower_lvl1_textur_tower;

    private void Start()
    {

        tower_lvl1.textur_tower = tower_lvl1_textur_tower;
    }
    void FixedUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        obj_spawn.transform.position = mousePosition;
    }

    public void select_an_object_town_lvl1()
	{ obj_spawn.GetComponent<SpriteRenderer>().sprite = tower_lvl1_textur_tower; }
    public class tower
    {
        public Sprite textur_tower;
        
    }
}