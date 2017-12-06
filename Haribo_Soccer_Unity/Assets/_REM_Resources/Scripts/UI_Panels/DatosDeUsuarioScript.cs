using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DatosDeUsuarioScript : MonoBehaviour {

	public TMP_InputField nombre, a_paterno, a_materno;
	public Button aceptar_btn;

	public void SetDatosDeUsuario()
	{
		GameDataScript.instance.nombre = nombre.text;
		GameDataScript.instance.apellido_paterno = a_paterno.text;
		GameDataScript.instance.apellido_materno = a_materno.text;
	}

	void FixedUpdate()
	{
		if (nombre.text == "" || a_paterno.text == "" || a_materno.text == "") {
			aceptar_btn.interactable = false;	
		} 
		else 
		{
			aceptar_btn.interactable = true;
		}
	}
}
