using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MyGameManager : MonoBehaviour {

	public static MyGameManager instance;
	public Vector3 gravity;
	public Shooter_Script shooter_reference;

	void Awake()
	{
		instance = this;
	}
	// Use this for initialization
	void Start () 
	{
		Physics.gravity = gravity;
		Boot_Script.instance.SetVRMode (true);
		StartCoroutine (TestShootRoutine ());
	}

	IEnumerator TestShootRoutine()
	{
		yield return new WaitForSeconds (5);

		for (int i = 0; i < 30; i++) 
		{
			shooter_reference.Shoot ();
			yield return new WaitForSeconds (1);
		}

		SpreadsheetsScript.instance.AddResultsToSheet ();
		yield return new WaitForSeconds(2);
		Boot_Script.instance.SwithScenes (1);
	}

}
