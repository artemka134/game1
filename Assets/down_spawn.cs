using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down_spawn : MonoBehaviour
{
    void OnMouseDown()
    {
        spawn_tower.ob.spawn_tower_mouse();
    }
}
