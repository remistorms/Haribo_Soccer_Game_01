using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Script : MonoBehaviour {

	public Transform[] ball_spawn_points;
	public float minForce, maxForce;
	public GameObject ball_prefab;
	public GameObject target_mesh;
	public GameObject bear_prefab;
	public float force;

	void Start()
	{
		//GET VARIABLES FROM GOOGLE SHEETS DONT FORGET THAT MAN
	}

	IEnumerator ShootRoutine()
	{
		//Spawn bear and ball
		Transform spawnPoint = ball_spawn_points[Random.Range(0, ball_spawn_points.Length)];
		GameObject spawned_bear = Instantiate (bear_prefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
		GameObject ball = Instantiate (ball_prefab,spawned_bear.transform.position + spawned_bear.transform.forward * 3, Quaternion.identity) as GameObject;
		//FORCE
		force = Random.Range(minForce, maxForce);
		spawned_bear.GetComponent<PanditaScript> ().StartPanditaRoutine (minForce, maxForce, force, ball);
		//Shoot

		//Wait and repeat
		yield return new WaitForSeconds(1);
	}

	public void Shoot(GameObject ball_to_shoot)
	{
		

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.S)) 
		{
			StartCoroutine (ShootRoutine ());
		}
	}

}
