using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataScript : MonoBehaviour {

	public static GameDataScript instance;

	[Header("Datos de Usuario")]
	public string nombre;
	public string apellido_paterno; 
	public string apellido_materno;

	[Header("Datos de Juego")]
	public string ticket;
	public string plaza;
	public string tienda;

	[Header("Resultados")]
	public int puntos;

	void Awake()
	{
		instance = this;
	}
}
