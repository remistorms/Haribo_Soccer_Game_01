using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

	void Start()
	{
		Debug.Log (this.gameObject.name + " is calling GetGameVariables() method from the instance SpreadsheetsScript...");
		SpreadsheetsScript.instance.GetGameVariables ();
	}
}
