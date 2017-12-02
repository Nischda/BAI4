using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class AgentSimple : Agent{

	private Entity _entity;
	private RuleSelection _ruleSelection;
	private Knowledge _knowledge;

	private int _viewDistance;
	private string _a;


	private Dictionary<string, List<Location>> _actionDictionary;
	//Todo: Reset everythign correctly
	//Todo: store basefaction to make it resetable
	//Todo: Add location class for better comparison and int[] to string conversion

	private void Awake(){
		_entity = GetComponent<Entity>();
		_viewDistance = PlayerPrefs.GetInt("EntityViewDistance");
		_viewDistance = 2; //Todo add slider
		_ruleSelection = new RuleSelection(_viewDistance, _entity);
	}

	/// <summary>
	/// The heart of the agent.
	/// Update Resources, current position(tile).
	/// Choose next action and execute it.
	/// </summary>
	public override void ChooseAction(){
		//Debug.Log("Turn of:" + _entity.name + " on:" + _s[0] + "|" + _s[1]);
		//Debug.Log("-------------------------TURN OF ENTITY: " + _entity.name + " OF FACTION: " + _entity.Faction + "-------------------------");
		_ruleSelection.UpdateKnowledge();
		_ruleSelection.Calculate();
		EntityAction action = _ruleSelection.GetBestAction();
		//Debug.Log("BESTACTION: " + action);
		ExecuteAction(action);

	}

	/// <summary>
	/// Translate EntityAction object into ActionType and Direction
	/// </summary>
	private void ExecuteAction(EntityAction action){
		switch (action.ActionType()){
			case "Move":
			//	Debug.Log(_entity.name + " moved to : " + action.Direction());
				Actions.Move(_entity, action.Direction());
				break;
			case "Attack":
			//	Debug.Log(_entity.name + " attacked: " + action.Direction());
				Actions.Attack(_entity, action.Direction());
				break;
			case "Wait":
			//	Debug.Log(_entity.name + " waits");
				Actions.Wait(_entity);
				break;
		}
	}

	public override void UpdateQ(){
		//No Learning
	}


/*

	private void Escape(Location location, List<Location> directNeighbors){
		Debug.Log(_entity.name + " escapes");
		_a = "Move";
		//Todo move towards allies instead of escape from enemy
		int x = location.X() * -1; //Move opposite direction of enemy
		int y = location.Y() * -1; //Move opposite direction of enemy

		if (x > 1){
//Right
			Location dir = new Location(1, 0);
			if (directNeighbors.Contains(dir)){
				_dir = dir;
			}
		}
		else if (x < 1){
//Left
			Location dir = new Location(-1, 0);
			if (directNeighbors.Contains(dir)){
				_dir = dir;
			}
		}
		else if (y > 1){
//Up
			Location dir = new Location(0, 1);
			if (directNeighbors.Contains(dir)){
				_dir = dir;
			}
		}
		else if (y < 1){
//Down
			Location dir = new Location(0, -1);
			if (directNeighbors.Contains(dir)){
				_dir = dir;
			}
		}
		else{
			//Todo make attack enemy if unable to move(Needs to be in range though)
		}
	}

*/
	/* RANDOM*
	private void MoveRandom(List<Location> directNeighbors){
		Debug.Log(_entity.name + " moves random");
		_a = "Move";
		int x = Random.Range(-1, 2);
		int y = 0;
		if (x == 0){
			y = Random.Range(-1, 2);
		}
		MoveTowards(new Location(x, y), directNeighbors);
	}
	*/


/*
		foreach (int[] location in testList){
			for (int i = 0; i < location.Length; i++){
				if (location[0] == right[0] && location[1] == right[1]){
					return true;
				}
			}
		}
*/
}