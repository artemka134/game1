using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
	public Animator img;
	public void Start_game()
	{
		img.SetBool("a", true);
		basic.money = 70;
		basic.score = 0;
		basic.time_boost = 0;
		basic.boost_time = 30;
		basic.boost = false;
		basic.tower.Clear();
		spawn_zombie.time_spawn = 4;
		spawn_zombie.decreasetm = 0.028f;
		spawn_tower.number_tower = 0;
		spawn_tower.time_bomb = 0;
		spawn_tower.mouse_spawn = false;
		spawn_tower.bomb = false;
		spawn_tower.bomb_time = false;
	}
	public void end_anim()
	{
		SceneManager.LoadScene(1);
		print(true);
	}
}
