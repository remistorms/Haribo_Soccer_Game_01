using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public static MainMenu instance;
	public PanelScript[] panels;

	void Awake()
	{
		instance = this;
		Boot_Script.instance.SetVRMode (false);
	}

	void Start()
	{
		foreach (var item in panels) 
		{
			item.InitPanels ();	
		}

		panels [0].EnablePanel ();
	}

	public void DisableAllPanels()
	{
		foreach (var item in panels) 
		{
			item.DisablePanel ();
		}
	}

	public void SwitchPanel(int panel_id)
	{
		DisableAllPanels ();
		panels [panel_id].EnablePanel ();
	}

	public void SwitchScenes(int scene_number)
	{
		SceneManager.LoadScene (scene_number);
	}
}
