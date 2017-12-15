using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using ToonyColors;

public class PanditaScript : MonoBehaviour {

	public Material[] pandita_materials;
	public SkinnedMeshRenderer pandita_mesh;
	public GameObject ball_prefab;
	public Animator pandita_animator;
	public Slider power_slider;
	public Image fill_image;
	public Color low_color, medium_color, high_color;
	public TextMeshProUGUI pandita_name;
	public CanvasGroup pandita_canvas;
	public Vector3 moveTarget;
	public float run_distance = 1f;
	Transform spawned_ball;
	public float valuePercent;

	void Start()
	{
		pandita_mesh.material = pandita_materials [Random.Range (0, pandita_materials.Length)];
		pandita_canvas.alpha = 0f;
		power_slider.value = 0f;
		fill_image.color = low_color;
	}

	void InitializePandita()
	{
		pandita_canvas.alpha = 0f;
		power_slider.value = 0f;
	}

	//Makes Pandita Move and Kick
	IEnumerator PanditaRoutine(float min, float max, float current_value, GameObject ball)
	{
		Debug.Log ("normalized slider value = " + power_slider.normalizedValue);
		power_slider.minValue = 0;
		power_slider.maxValue = max;
		power_slider.value = current_value;
		float normalized_value = power_slider.normalizedValue;
		power_slider.value = min;

		pandita_canvas.DOFade (1f, 0.5f);


		yield return new WaitForSeconds (0.5f);

		power_slider.DOValue (current_value, 0.5f);

		if (normalized_value > 0 && normalized_value <= 0.33f ) 
		{
			fill_image.DOColor (low_color, 0.5f);
		}

		else if (normalized_value > 0.33f && normalized_value <= 0.66f ) 
		{
			fill_image.DOColor (medium_color, 0.5f);
		}

		else if (normalized_value > 0.66f) 
		{
			fill_image.DOColor (high_color, 0.5f);
		}

		yield return new WaitForSeconds (1.0f);
		//Makes pandita look at ball
		transform.LookAt (ball.transform);
		yield return new WaitForSeconds (1.0f);
		pandita_animator.SetBool("is_bear_running", true);
		transform.DOMove (ball.transform.position, 2.0f);
		yield return new WaitForSeconds (1.5f);
		pandita_animator.SetTrigger ("kick_ball");
	}

	void Update()
	{
		
	}

	public void StartPanditaRoutine(float min, float max, float value, GameObject ball)
	{
		StartCoroutine (PanditaRoutine(min, max, value, ball));
	}
}
