using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoomLit : MonoBehaviour {

	MeshRenderer room_mesh;
	public Color end_color;

	void Awake()
	{
		room_mesh = GetComponent<MeshRenderer> ();
		end_color = room_mesh.material.color;
		room_mesh.material.color = Color.black;
	}

	void Start()
	{
		StartCoroutine (TurnOnLights ());
	}

	IEnumerator TurnOnLights()
	{
		yield return new WaitForSeconds (3);
		room_mesh.material.DOColor (end_color, 15.0f);
	}
}
