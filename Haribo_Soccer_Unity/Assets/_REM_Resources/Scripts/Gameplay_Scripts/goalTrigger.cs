using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalTrigger : MonoBehaviour {

	void Start()
	{
		GetComponent<MeshRenderer> ().enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "football") 
		{
			Debug.Log ("GOAL");
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube (transform.position, transform.localScale);
	}
}
