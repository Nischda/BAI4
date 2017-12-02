using System.Collections.Generic;
using UnityEngine;

public static class EventManager {

	private static List<string> _eventList;


	public static void Reset(){
		_eventList = new List<string>();
		//Example: _resetOnGoalEncounter = 1 == PlayerPrefs.GetInt("ResetOnGoalEncounter"); // 1 == true, 0 == false
	}
	
	public static void HandleEvents(){
		foreach (string eventName in _eventList){
			//Example: if (eventName == "Goal" && _resetOnGoalEncounter) GameManager.ResetGame();
		}
		_eventList = new List<string>(); //Reset Event
	}
	
	//EVENTS
	public static void AddEvent(string eventName){
		_eventList.Add(eventName);
	}
}
