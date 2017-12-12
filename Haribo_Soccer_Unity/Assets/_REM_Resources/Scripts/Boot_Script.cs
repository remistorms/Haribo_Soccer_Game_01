using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.SceneManagement;

public class Boot_Script : MonoBehaviour {

	public static Boot_Script instance;
	public GameObject[] boot_objects;
	public int test_int;

	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		} 
		else 
		{
			Debug.Log ("An instance already exists.... destroying...." + this.gameObject.name);
			Destroy (this.gameObject);
			return;
		}

		SetVRMode (false);
		DontDestroyOnLoad (gameObject);

	}

	public void SwithScenes(int scene_number)
	{
		SceneManager.LoadSceneAsync (scene_number);
	}

	public void SwithScenes(string scene_name)
	{
		SceneManager.LoadSceneAsync (scene_name);
	}

	public void SetVRMode(bool myBool)
	{
		UnityEngine.XR.XRSettings.enabled = myBool;
	}


		
}