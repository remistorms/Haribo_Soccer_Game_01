using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GoogleSheetsToUnity;

public class ListaDePremios : MonoBehaviour {

	public TMP_Dropdown premioss_dropdown;
	public List<string> premios_strings;
	public Button aceptar_btn;

	void Start()
	{
		GetAllPremiosFromWorksheet ();
	}

	public void GetAllPremiosFromWorksheet()
	{
		WorksheetData worksheetInformation = SpreadsheetsScript.instance.haribo_spreadsheet.LoadWorkSheet ("premios").LoadAllWorksheetInformation ();

		foreach (RowData row in worksheetInformation.rows) 
		{
			foreach (CellData cell in row.cells) 
			{
				premios_strings.Add (cell.value);
			}
		}
		premioss_dropdown.AddOptions (premios_strings);
	}


	public void SetPremioData()
	{
		GameDataScript.instance.premio_seleccionado = premioss_dropdown.captionText.text;
	}
}
