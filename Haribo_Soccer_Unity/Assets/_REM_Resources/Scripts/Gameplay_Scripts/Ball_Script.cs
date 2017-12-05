using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour {

	public Rigidbody ball_rb;

	void Start()
	{
		Destroy (gameObject, 5);
	}
}
