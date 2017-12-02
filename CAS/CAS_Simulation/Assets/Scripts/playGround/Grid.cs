using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Random = UnityEngine.Random;

public class Grid : MonoBehaviour
{

	public GameObject GridTile;
	public bool UseSeed = false;
	
	private int _width;
	private int _height;
	private float _offsetFactor;

	private List<Location> _tileList;
	private Dictionary<Location, Encounter> _locationEncounters;
	private Dictionary<Encounter, Location> _encounterStartLocations;

	public Vector3 GetVector3(int x, int z){
		return new Vector3(x*_offsetFactor, 0.4f, z*_offsetFactor);
	}

	private void DestroyChildren(){
		foreach (Transform child in transform) {
			Destroy(child.gameObject);
		}
	}

	private void Reset(){
		DestroyChildren();
		InitializePrefs();
		//If not using old seed -> generate new one
		if (!UseSeed){PlayerPrefs.SetInt("Seed", Random.Range(0, 999999));}
		Random.InitState(PlayerPrefs.GetInt("Seed"));
		
		_tileList = new List<Location>();
		_locationEncounters = new Dictionary<Location, Encounter>();
		_encounterStartLocations = new Dictionary<Encounter, Location>();
		
		transform.position = new Vector3(0,0,0);
	}

	private void InitializePrefs(){
		_width = PlayerPrefs.GetInt("Width");
		_height = PlayerPrefs.GetInt("Height");
		_offsetFactor = PlayerPrefs.GetInt("Offset")/100f+1; // /100 => Percent, +1 => width/height of tile 
	}
	
	//Invalid tiles are outside of indexing
	public bool IsValidLocation(Location location){
		int x = location.X();
		int y = location.Y();
		if (x < 0 || x >= _width) return false;
		return y >= 0 && y < _height;
	}
	
	//Occupied tiles contain at least one Encounter
	public bool IsOccupiedTile(Location location){
		return _locationEncounters.ContainsKey(location);
	}
	
	//ENCOUNTER (Obstacles, Goals, Entities)
	public Encounter GetEncounter(Location location){
		if (_locationEncounters.ContainsKey(location)){
			return _locationEncounters[location];
		}
		return null;
	}

	public void AddEncounter(Encounter encounter, Location location){
		_locationEncounters.Add(location, encounter);
	}
	
	public void RemoveEncounter(Encounter encounter, Location location){
		_locationEncounters.Remove(location);
		_encounterStartLocations.Remove(encounter);
	}
	
	//ENTITY
	//returns encounter location as int array of x,z
	public Location GetEncounterLocation(Encounter encounter){
		return _locationEncounters.FirstOrDefault(x => x.Value == encounter).Key;
	}
	
	//Remove Entity as Encounter and Entity
	public void RemoveEntity(Encounter encounter){
		Location entityLocation = GetEncounterLocation(encounter);
		_locationEncounters.Remove(entityLocation);
	}

	public Dictionary<Location, Encounter> GetNeighbours(Entity entity, int viewDistance){
		Location entityLocation = GetEncounterLocation(entity);
		Dictionary<Location, Encounter>   neighbourLocations = new 	Dictionary<Location, Encounter>();
		
		int minX = entityLocation.X() - viewDistance;
		int minY = entityLocation.Y() - viewDistance;
		int maxX = entityLocation.X() + viewDistance;
		int maxY = entityLocation.Y() + viewDistance;
		
		for (int x = minX; x <= maxX; x++){
			for (int y = minY; y <= maxY; y++){
				Location location = new Location(x, y);
				if (IsValidLocation(location)){
					if (_locationEncounters.ContainsKey(location)){
						neighbourLocations.Add(location, _locationEncounters[location]);
					}
					else{
						neighbourLocations.Add(location, null); //Todo test
					}
				}
			}
		}
		neighbourLocations.Remove(entityLocation); //Remove the entity itself
		return neighbourLocations;
	}
	
	//Remove previous locations as Encounter and Entity and add new ones.
	public void SetEncounterLocation(Encounter encounter, Location location){
		RemoveEntity(encounter);
		_locationEncounters[location] = encounter;
		encounter.transform.localPosition = new Vector3(location.X()*_offsetFactor, 0.4f, location.Y()*_offsetFactor);
	}
	
	public void ResetEncounter(){
		foreach (Encounter encounter in _encounterStartLocations.Keys){
			encounter.Reset();
			SetEncounterLocation(encounter, _encounterStartLocations[encounter]);
		}
	}
	
	//CREATE
	//Create 2 dimensional grid and stores it in _tileList
	public void CreateGrid(){
		Reset();
		for (int x = 0; x < _width; x++) {
			for (int y = 0; y < _height; y++){
				var go = Instantiate(GridTile);
				go.transform.SetParent(this.transform);
				go.transform.localPosition = new Vector3(x*_offsetFactor, 0, y*_offsetFactor);
				go.name = "GridTile_" + x + "_" + y;
				_tileList.Add(new Location(x,y)); //Todo check if necessary for smth.
			}
		}
	}

	//Look for unoccupied tiles and add Encounter to them based on Action and count.
	public void FillGrid(Func<int,int,int, Encounter> createGo, int count){
		int placed = 0;
		while (placed < count){
			int x = Random.Range(0, _width);
			int y = Random.Range(0, _height);
			Location location = new Location(x,y);
			if (!IsOccupiedTile(location)){
				AddEncounter(createGo(x,y,placed), location);
				placed++;
			}
		}
	}

	public void Center(){				
		//center, subtract 0.5width, height width if %2 == 1
		transform.position = new Vector3(-0.5f*_width*_offsetFactor,0,-0.5f*_height*_offsetFactor);
	}
}
