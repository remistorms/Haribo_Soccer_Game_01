using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ProgressUI : MonoBehaviour {

	RectTransform myRect;
	public static ProgressUI instance;
	public TextMeshProUGUI percentage_label;
	public Slider progress_bar;
	public float progress;
	bool progressBarEnabled = false;

	void Awake()
	{
		instance = this;
		myRect = GetComponent<RectTransform> ();
		myRect.transform.localScale = Vector3.zero;
	}

	void Update()
	{
		if (progressBarEnabled) 
		{
			percentage_label.text = (progress_bar.value * 100).ToString ("##") + " %";
		}

	}

	public void LoadSceneRoutine(int scene_number)
	{
		StartCoroutine (LoadSceneWithProgress (scene_number));
	}

	IEnumerator LoadSceneWithProgress(int myInt)
	{
		progressBarEnabled = true;
		ShowProgressUI ();
		yield return new WaitForSeconds (0.25f);
		progress_bar.DOValue (1, 2);
		yield return new WaitForSeconds(0.75f);
		Boot_Script.instance.SwithScenes (myInt);
		yield return new WaitForSeconds (0.5f);
		HideProgressUI ();
		progressBarEnabled = false;
	}

	public void ShowProgressUI()
	{
		myRect.DOScale (Vector3.one, 0.25f);
	}

	public void HideProgressUI()
	{
		myRect.DOScale (Vector3.zero, 0.25f);
	}
}
