using System.Collections.Generic;
using UnityEngine;

public static class GameManager {
	
	//Todo: wait for turn to finish before reseting/new game to avoid exceptions
	//Todo: Enable Zoom
	//Todo: Add comments
	//Todo: add Dijkstra to guarantee valid paths from any entity to at least one goal.
	//Todo: add chartlength to ui or increase chartlength whenrefreshing
	//Todo: make camera adjust to gridsize
	//Todo: Adjust EntityColor to Graphline color or display id on both
	//Todo: Build export for Graph data
	//Todo: Make Machine Learning recursive via path history iteration
	//Todo: Limit Settings to valid ones. max objects < width * height
	//Todo: Add Random Algorithm and Button for Settings
	//Todo: Note: Changing settings will disable reset function.
	private static Grid _grid;
	private static EntityFactory _entityFactory;
	private static UIManager _uiManager;
	private static InputController _inputController;
	private static Utility _utility;

	public static void Reset(){
		_grid = GameObject.Find("Grid").GetComponent<Grid>();
		_entityFactory = GameObject.Find("EntityFactory").GetComponent<EntityFactory>();
		_uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
		_inputController = GameObject.Find("InputController").GetComponent<InputController>();
		_utility = GameObject.Find("Utility").GetComponent<Utility>();
		Scanner.Reset();
	}


	public static void ResetGame(){
		Reset();
		_inputController.Reset();
		EventManager.Reset();
		_uiManager.ResetRound();
		_uiManager.IncrementText("Rounds", 1);
		TurnManager.ResetCurController();
		_utility.Wait(PlayerPrefs.GetInt("ActionCooldown") / 1000000f, () => {
			_grid.ResetEncounter();
			TurnManager.StartGame();
		});
	}
	
	public static void NewGame(){
		Reset();
		_inputController.Reset();
		EventManager.Reset();
		_uiManager.ResetGame(); 
		Enviroment.Reset();
		TurnManager.ResetCurController();
		_utility.Wait(PlayerPrefs.GetInt("ActionCooldown") / 1000000f, () => {
			TurnManager.Reset();
			_grid.UseSeed = false;
			_grid.CreateGrid();
			_entityFactory.CreateEntities();
			TurnManager.StartGame();
		});
	}
	
	//unused
	public static void NewGameOldSeed(){
		Reset();
		_inputController.Reset();
		_uiManager.ResetGame();
		EventManager.Reset();
		Enviroment.Reset();
		TurnManager.ResetCurController();
		_utility.Wait(PlayerPrefs.GetInt("ActionCooldown") / 1000000f, () => {
			TurnManager.Reset();
			_grid.UseSeed = true;
			_grid.CreateGrid();
			_entityFactory.CreateEntities();
			TurnManager.StartGame();
		});
	}
}
