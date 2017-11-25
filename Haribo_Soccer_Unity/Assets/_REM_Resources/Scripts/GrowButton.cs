using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrowButton : MonoBehaviour {

	public Vector2 original_scale;
	public float tween_duration = 0.2f;

	void Start()
	{
		original_scale = transform.localScale;
	}

	public void Grow()
	{		
		transform.DOScale (original_scale * 1.1f, tween_duration);
	}

	public void Shrink()
	{
		transform.DOScale (original_scale, tween_duration);
	}
}
