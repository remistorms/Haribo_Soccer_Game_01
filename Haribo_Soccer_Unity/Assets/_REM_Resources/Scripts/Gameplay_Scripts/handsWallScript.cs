using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handsWallScript : MonoBehaviour {

	void Start()
	{
		GetComponent<MeshRenderer> ().enabled = false;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube (transform.position, transform.localScale);
	}
}
