using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class InfoMessages : MonoBehaviour {

	public static InfoMessages instance;
	public CanvasGroup info_canvas_group;
	public RectTransform infoRect;
	public TextMeshProUGUI title_label, info_label;
	public Button aceptar_btn;



	void Awake()
	{
		instance = this;
		infoRect.localScale = Vector2.zero;

	}

	public void ShowInfoPanel(string info_title, string info_text)
	{
		title_label.text = info_title;
		info_label.text = info_text;
		infoRect.DOScale (Vector3.one, 0.5f);
	}

	public void HideInfoPanel()
	{
		infoRect.DOScale (Vector3.zero, 0.2f);
		aceptar_btn.onClick.RemoveAllListeners ();
	}
}
