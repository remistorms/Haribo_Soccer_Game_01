using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Script : MonoBehaviour {

	public Transform[] ball_spawn_points;
	public float minForce, maxForce;
	public GameObject ball_prefab;
	public GameObject target_mesh;

	void Start()
	{
		//GET VARIABLES FROM GOOGLE SHEETS DONT FORGET THAT MAN
	}

	IEnumerator ShootRoutine()
	{
		//Spawn bear and ball

		//Show Shot UI

		//Shoot

		//Wait and repeat
		yield return new WaitForSeconds(1);
	}

	public void Shoot()
	{
		//Spawn ball and Bear at selected points
		Transform point = ball_spawn_points[Random.Range(0, ball_spawn_points.Length)];
		GameObject ball = Instantiate(ball_prefab, point.transform.position, Quaternion.identity) as GameObject;
		//Select random point to shoot

		Vector3 randomPointToShoot = target_mesh.transform.position + (new Vector3 (
			                             Random.Range (-target_mesh.transform.localScale.x / 2, target_mesh.transform.localScale.x / 2),
			                             Random.Range (-target_mesh.transform.localScale.y / 2, target_mesh.transform.localScale.y / 2),
			                             0));
		//Get direction vector
		Vector3 shoot_direction =  randomPointToShoot - ball.transform.position;

		//Add force to ball
		float force = Random.Range(minForce, maxForce);
		ball.GetComponent<Rigidbody> ().AddForce (shoot_direction * force, ForceMode.Force); 

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.S)) 
		{
			Shoot ();	
		}
	}
}
