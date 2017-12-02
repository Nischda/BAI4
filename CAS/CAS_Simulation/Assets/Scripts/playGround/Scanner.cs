using System;
using System.Collections.Generic;
using UnityEngine;

public static class Scanner {
	
	private static Grid _grid;
	public static void Reset(){
		_grid = GameObject.Find("Grid").GetComponent<Grid>();
	}

	public static Location GetLocation(Entity entity){
		return _grid.GetEncounterLocation(entity);
	}

	//Todo: filter entity?
	public static Dictionary<string, List<Location>> GetNeighboursByFaction(Entity entity, int viewDistance){
		Location entityLocation = _grid.GetEncounterLocation(entity);
		Dictionary<Location, Encounter> neighbours = _grid.GetNeighbours(entity, viewDistance);
		Dictionary<string, List<Location>> neighboursByFaction = new Dictionary<string, List<Location>>();

		string faction;
		foreach (Location location in neighbours.Keys){
			Encounter encounter = neighbours[location];
			faction = encounter == null ? "Empty" : encounter.GetFaction();
			
			if (!neighboursByFaction.ContainsKey(faction)){
				neighboursByFaction.Add(faction, new List<Location>());
			}
			if (!location.Equals(entityLocation)){ //Todo move outside loop
				//locations are relative to acting entity.
				neighboursByFaction[faction].Add(new Location(location.X() - entityLocation.X(), location.Y() - entityLocation.Y()));
			}
			
			
		}
		return neighboursByFaction;
	}
	
}