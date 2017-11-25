using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Boot_Script : MonoBehaviour {

	void Start()
	{
		UnityEngine.XR.XRSettings.enabled = false;
		DontDestroyOnLoad (gameObject);
	}
}
