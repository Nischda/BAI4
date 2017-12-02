
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class Knowledge{
   private Entity _entity;
   private string _faction;
   private Dictionary<string, List<Location>> _neighboursByFaction;
   private Dictionary<string, Dictionary<Location, int>> _distancesByFactions;
    private Dictionary<Location, string> _neighbours;
   private Dictionary<Location, string> _directNeighbours;
   private Dictionary<string, int> _factionBalance;

    public Knowledge(Entity entity, Dictionary<string, List<Location>> neighboursByFaction){
        _entity = entity;
        _faction = entity.Faction;
        _neighboursByFaction = neighboursByFaction;
        CalculateDistancesToNeighbours();
        CalculateNeighbours();
        CalculateDirectNeighbours();
        CalculateFactionBalance();
        CalculateClosestEnemy();
    }

    private void CalculateDistancesToNeighbours(){
        _distancesByFactions = new Dictionary<string, Dictionary<Location, int>>();
        foreach (string faction in _neighboursByFaction.Keys){
            foreach (Location location in _neighboursByFaction[faction]){
                int distance = Math.Abs(location.X()) + Math.Abs(location.Y());
                                   
                if (!_distancesByFactions.ContainsKey(faction)){
                    _distancesByFactions.Add(faction, new Dictionary<Location, int>());
                }
                _distancesByFactions[faction].Add(location,distance);
            }
        }
    }
    
	
    private void CalculateDirectNeighbours(){
        _directNeighbours = new Dictionary<Location, string>();
        foreach ( string faction in  _distancesByFactions.Keys){
            Dictionary<Location, int> distanceToFactionEncounter = _distancesByFactions[faction];
            foreach (Location location in distanceToFactionEncounter.Keys){
                //Debug.Log(_entity.name + " has possible neighbour: " + location[0] + "|" + location[1] + "on distance: " + distanceToFactionEncounter[location]);
                if (distanceToFactionEncounter[location] == 1){
                    _directNeighbours.Add(location, faction);
                    //Debug.Log(_entity.name + " has neighbour: " + location[0] + "|" + location[1]);
                }
            }
        }
    }
	
    private void CalculateNeighbours(){
        _neighbours = new Dictionary<Location, string>();
        foreach (string faction in _neighboursByFaction.Keys){
            foreach (Location location in _neighboursByFaction[faction]){
                _neighbours.Add(location,faction);
            }
        }
    }
    
    private void CalculateFactionBalance(){
        Dictionary<string, int> _factionBalance = new Dictionary<string, int>();
        _factionBalance[_entity.Faction] = 0;
        _factionBalance["Enemies"] = 0;
        _factionBalance["Neutral"] = 0;
        foreach (string faction in _neighboursByFaction.Keys){
            if (faction == _entity.Faction || faction == "Neutral") _factionBalance[faction] += 1;
            else{
                //Debug.Log(faction + " is enemy in Range");
                _factionBalance["Enemies"] += 1;
            }
        }
    }
    
    //Todo adjust to make useful
    private DistantEncounter CalculateClosestEnemy(){
        int closestDistance = Int32.MaxValue;
        Location closestLocation = null;
        foreach (string faction in _distancesByFactions.Keys){
            if (faction !=  _entity.Faction && faction != "Neutral"){
                foreach (Location location in _distancesByFactions[faction].Keys){
                    if (_distancesByFactions[faction][location] < closestDistance){
                        closestDistance = _distancesByFactions[faction][location];
                        closestLocation = location;
                     //   Debug.Log( _entity.Faction + " " + closestLocation + " " + closestDistance);
                    }
                }
                if (closestLocation != null){
                    return new DistantEncounter(closestDistance, closestLocation);
                }
            }
        }
        return null;
    }

    public String GetFactionOn(Location location){
        if (!_neighbours.ContainsKey(location)) return null;
        return _neighbours[location];
    }

    public string GetFaction(){
        return _faction;
    }

    
   public Dictionary<string, List<Location>> GetNeighboursByFaction(){
      return _neighboursByFaction;
   }
   
    public Dictionary<string, Dictionary<Location, int>> GetDistancesToNeighbours(){
      return _distancesByFactions;
   }
    
    public Dictionary<Location, string> GetNeighbours(){
        return _neighbours;
    }
    
    public Dictionary<Location, string> GetDirectNeighbours(){
      return _directNeighbours;
   }
   
    public Dictionary<string, int> GetFactionBalance(){
      return _factionBalance;
   }
}