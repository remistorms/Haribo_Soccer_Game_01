using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GoogleSheetsToUnity;

public class DatosDeCompraScript : MonoBehaviour {

	public TMP_Dropdown tiendas_dropdown;
	public List<string> tiendas_strings;
	public int number_of_stores;
	public Button aceptar_btn;
	public TMP_InputField ticket_input_field;

	void Start()
	{
		GetAllStoresFromWorksheet ();
	}

	public void GetAllStoresFromWorksheet()
	{
		WorksheetData worksheetInformation = SpreadsheetsScript.instance.haribo_spreadsheet.LoadWorkSheet ("tiendas").LoadAllWorksheetInformation ();

		foreach (RowData row in worksheetInformation.rows) 
		{
			foreach (CellData cell in row.cells) 
			{
				tiendas_strings.Add (cell.value);
			}
		}
		tiendas_dropdown.AddOptions (tiendas_strings);
	}

	void FixedUpdate()
	{
		if (ticket_input_field.text == "") 
		{
			aceptar_btn.interactable = false;	
		} 
		else 
		{
			aceptar_btn.interactable = true;
		}
	}

	public void SetStoreData()
	{
		GameDataScript.instance.ticket = ticket_input_field.text;
		GameDataScript.instance.tienda = tiendas_dropdown.captionText.text;
	}
}
