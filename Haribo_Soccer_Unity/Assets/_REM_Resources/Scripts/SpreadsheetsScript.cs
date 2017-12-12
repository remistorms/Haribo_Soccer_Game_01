using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleSheetsToUnity;

public class SpreadsheetsScript : MonoBehaviour {

	public static SpreadsheetsScript instance;

	SpreadSheetManager manager;
	public GS2U_SpreadSheet haribo_spreadsheet;
	public List<GS2U_Worksheet> haribo_worksheets;
	public List<string> worksheets_names;


	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		ReloadWorksheets ();
	}

	public void ReloadSheetsData()
	{
		//StartCoroutine (ReloadWorksheetRoutine ());
	}

	void GetSpreadsheets()
	{
		haribo_spreadsheet = manager.LoadSpreadSheet ("Haribo_Soccer_Variables");
	}

	void GetWorksheets()
	{
		haribo_worksheets = haribo_spreadsheet.GetAllWorkSheets();
		worksheets_names = haribo_spreadsheet.GetAllWorkSheetsNames ();
	}

	public void ReloadWorksheets()
	{
		CheckConnection ();
		ClearOldSheetInfo ();
		manager = new SpreadSheetManager ();
		GetSpreadsheets ();
		GetWorksheets ();
	}

	void ClearOldSheetInfo()
	{
		if (haribo_worksheets!= null) 
		{
			haribo_worksheets.Clear ();
		}
	}

	void CheckConnection()
	{
		Debug.Log ("CHECKIN CONNECTION");

		switch (Application.internetReachability)
		{
		case NetworkReachability.NotReachable:
			InfoMessages.instance.ShowInfoPanel ("Error de Conexion", "Este juego requiere conexion a internet para funcionar. Active sus datos moviles o conectese a una red WiFi para continuar.");
			break;

		case NetworkReachability.ReachableViaCarrierDataNetwork:
			InfoMessages.instance.ShowInfoPanel ("Conexion Exitosa", "Conectado a internet usando datos moviles");
			InfoMessages.instance.aceptar_btn.onClick.AddListener (ClicLoad);
			//GetGameVariables ();
			break;

		case NetworkReachability.ReachableViaLocalAreaNetwork:
			InfoMessages.instance.ShowInfoPanel ("Conexion Exitosa", "Conectado a internet por medio de WiFi");
			InfoMessages.instance.aceptar_btn.onClick.AddListener (ClicLoad);
			//GetGameVariables ();
			break;

		default:
			break;
		}
	}

	void ClicLoad()
	{
		ProgressUI.instance.LoadSceneRoutine (1);
	}

	public void GetGameVariables()
	{
		Debug.Log ("GETTING GAME VARIABLES FROM GOOGLE SPREADSHEETS");

		//Target Mesh Variables
		float target_mesh_pos_x =  float.Parse(haribo_worksheets [0].GetCellData ("B", 3).value);
		float target_mesh_pos_y = float.Parse (haribo_worksheets [0].GetCellData ("B", 4).value);
		float target_mesh_pos_z = float.Parse (haribo_worksheets [0].GetCellData ("B", 5).value);
		float target_mesh_width= float.Parse (haribo_worksheets [0].GetCellData ("B", 6).value);
		float target_mesh_height= float.Parse (haribo_worksheets [0].GetCellData ("B", 7).value);
		float target_mesh_depth = float.Parse (haribo_worksheets [0].GetCellData ("B", 8).value);
		GameVariables.instance.tm_position = new Vector3 (target_mesh_pos_x, target_mesh_pos_y, target_mesh_pos_z);
		GameVariables.instance.tm_scale = new Vector3 (target_mesh_width, target_mesh_height, target_mesh_depth);

		//Shooter Variables
		float minForce =  float.Parse(haribo_worksheets [0].GetCellData ("B", 11).value);
		float maxForce =  float.Parse(haribo_worksheets [0].GetCellData ("B", 12).value);
		GameVariables.instance.minForce = minForce;
		GameVariables.instance.maxForce = maxForce;

	}

	public void AddResultsToSheet()
	{
		int myRandom = Random.Range (0, 30);
		GS2U_Worksheet gameplaysWorksheet = haribo_spreadsheet.LoadWorkSheet ("gameplays");

		gameplaysWorksheet.AddRowData (new Dictionary<string, string>
			{
				{"nombre", GameDataScript.instance.nombre},
				{"paterno", GameDataScript.instance.apellido_paterno},
				{"materno", GameDataScript.instance.apellido_materno},
				{"tiros", "30"},
				{"detenidos", myRandom.ToString()},
				{"goles", (30 - myRandom).ToString()},
				{"puntos", GameDataScript.instance.puntos.ToString()},
				{"fecha", System.DateTime.Now.ToString("dd/MM/yyyy")},
				{"hora", System.DateTime.Now.TimeOfDay.ToString()}
			
			});

		Boot_Script.instance.test_int++;
	}

}
