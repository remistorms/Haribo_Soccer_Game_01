using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

	void Start()
	{
		SpreadsheetsScript.instance.GetGameVariables ();
	}
}
