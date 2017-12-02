using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public static class TurnManager {

	private static UIManager _uiManager;
	private static Utility _utility;
	private static EntityController _curController;
	private static List<EntityController> _controllerList;
	private static bool _gameEnd = false;
	
	public static void SetGameEnd(bool gameEnd){_gameEnd = gameEnd;}
	public static void AddController(EntityController controller){_controllerList.Add(controller);}
	public static void RemoveController(EntityController controller){_controllerList.Remove(controller);}
	
	public static void Reset(){
		_uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
		_utility = GameObject.Find("Utility").GetComponent<Utility>();
		_controllerList = new List<EntityController>();
	}

	public static void ResetCurController(){
		_curController = null;
		_gameEnd = true;
	}
	
	public static void StartGame(){
		_utility.Wait(PlayerPrefs.GetInt("RoundCooldown")/1000000f, () => {
			if (_controllerList.Count > 0){//Only start/continue if entities exist
				_curController = _controllerList[0];
				_gameEnd = false;
				NextTurn();
			}
		});
	}

	public static void NextTurn(){ //Entities end their turn by calling an action which forces this.
		_utility.Wait (PlayerPrefs.GetInt("ActionCooldown")/100000000f, () => { //To avoid cpu overload
			if (_gameEnd) return; //Stop game on End and Script on Reset as it keeps running even when deleted
		Profiler.BeginSample("AnyAgent");
			_curController.ManageActions(1);
		Profiler.EndSample();
		});
		Profiler.BeginSample("SetNextEntity");
		SetNextEntity();
		Profiler.EndSample();
	}
	
	private static void SetNextEntity(){
		if (_controllerList.Count == 0)_gameEnd = true;
		else{
			_curController.UnHighlight();
			int curControllerId = _controllerList.IndexOf(_curController);
			if (curControllerId < _controllerList.Count - 1){
				_curController = _controllerList[curControllerId + 1];
			}
			//Reset for next Game loop
			else{
				_curController = _controllerList[0];
				_uiManager.IncrementText("Turns", 1);
			}
		}
		_curController.Highlight();
	}
}
