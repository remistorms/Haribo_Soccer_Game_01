using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_mesh : MonoBehaviour {

	public Vector3 myScale;

	void Start()
	{
		GetComponent<MeshRenderer> ().enabled = false;	
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube (transform.position, transform.localScale);
	}
}
