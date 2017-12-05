using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PanelScript : MonoBehaviour {

	public bool panel_active;
	RectTransform panel_rect;
	CanvasGroup panel_canvas_group;

	void Awake()
	{
		panel_rect = GetComponent<RectTransform> ();
		panel_canvas_group = GetComponent<CanvasGroup> ();
		panel_rect.offsetMax = panel_rect.offsetMin = Vector2.zero;
	}

	public void DisablePanel()
	{
		panel_canvas_group.interactable = false;
		panel_canvas_group.blocksRaycasts = false;
		panel_canvas_group.DOFade (0, 0.5f);
	}

	public void EnablePanel()
	{
		panel_canvas_group.interactable = true;
		panel_canvas_group.blocksRaycasts = true;
		panel_canvas_group.DOFade (1, 0.5f);
	}

	public void InitPanels()
	{
		panel_canvas_group.interactable = false;
		panel_canvas_group.blocksRaycasts = false;
		panel_canvas_group.alpha = 0;
	}

}
