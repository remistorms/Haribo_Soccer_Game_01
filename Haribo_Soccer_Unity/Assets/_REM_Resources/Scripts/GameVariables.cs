using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour {

	public static GameVariables instance;

	//You can place all boolean variables here
	[Header("Target mesh variables")]
	public Vector3 tm_position;
	public Vector3 tm_scale;

	//You can place all int variables here
	[Header("Shooter Variables")]
	public float minForce, maxForce;

	//You can place all float variables here
	[Header("Ball Variables")]
	public float mass = 0.1f;
	public float drag = 1.0f;
	public float angularDrag = 0.5f;

	void Awake()
	{
		instance = this;
	}
}
