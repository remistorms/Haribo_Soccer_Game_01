using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ReviewPanel : MonoBehaviour {

	public TextMeshProUGUI nombre_label, ticket_label, tienda_label, premio_label;

	//Gets the information from the GameDataScript and shows it on the screen before players chose to play
	public void FillReviewInfo()
	{
		nombre_label.text = "Nombre: " + GameDataScript.instance.nombre + " " +	GameDataScript.instance.apellido_paterno + " " + GameDataScript.instance.apellido_materno;
		ticket_label.text = "Ticket: " + GameDataScript.instance.ticket;
		tienda_label.text = "Tienda: " + GameDataScript.instance.tienda;
		premio_label.text = "Premio: " + GameDataScript.instance.premio_seleccionado;
	}
}
