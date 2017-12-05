using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordsScript : MonoBehaviour {

	public static RecordsScript instance;
	//Use this script to save data
	void Awake()
	{
		instance = this;	
	}
}
