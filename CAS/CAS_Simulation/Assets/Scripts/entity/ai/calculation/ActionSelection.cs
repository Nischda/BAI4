using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = System.Random;

public class ActionSelection{

    private Random rand = new Random();
    private  Dictionary<string, List<Location>> _actionSelection;
    private int _minX;
    private int _minY;
    private int _maxX;
    private int _maxY;
    
    public ActionSelection(int viewDistance){
        _minX = -viewDistance;
        _minY = -viewDistance;
        _maxX = viewDistance;
        _maxY = viewDistance;
        Reset();
    }

    private void Reset(){
        _actionSelection = new Dictionary<string, List<Location>>();
        _actionSelection.Add("Attack", new List<Location>());
        _actionSelection.Add("Engage", new List<Location>());
        _actionSelection.Add("Escape", new List<Location>());
        _actionSelection.Add("Scout", new List<Location>());
        
        
        //Todo No limti to existing grid, as border is malus but fix to enviroment
        for (int x = _minX; x <= _maxX; x++){
            for (int y = _minY; y <= _maxY; y++){
                Location location = new Location(x, y);
                _actionSelection["Attack"].Add(location);
                location = new Location(x, y);
                _actionSelection["Engage"].Add(location);
                location = new Location(x, y);
                _actionSelection["Escape"].Add(location);
                location = new Location(x, y);
                _actionSelection["Scout"].Add(location);
            }
        }
    }

    //Todo improve by removing indexof somehow?
    public void AddV(string actionType, Location location, float f){
        if (_actionSelection[actionType].Contains(location)){
            int i = _actionSelection[actionType].IndexOf(location);
      //      Debug.Log(actionType + " + " + f);
            _actionSelection[actionType][i].AddV(f);
        }
        
    }

    /// <summary>
    /// Get Action with highest Q-Value.
    /// Base Action: Wait.
    /// </summary>
    /// <returns></returns>
    public EntityAction GetBestAction(){
        Location maxDirection = new Location(0,0); //Base: Not moving
    //    Debug.Log(_actionSelection);
    //    Debug.Log("--------------------FIND BEST ------------------------");
        string maxAction = "Move";
        foreach (string action in _actionSelection.Keys){
            foreach (Location direction in _actionSelection[action]){
             //  Debug.Log(action + direction);
             //  Debug.Log("Direction: " + direction + " - Value: " + direction.V());
                if(IsMeleeDirection(direction)){
                    if (direction.V() >= maxDirection.V()){
                        if (direction.V() == maxDirection.V()){ //Todo improve
                            if (rand.NextDouble() >= 0.5f){
                                //Avoid using alwas using first solution fo exact float
                                maxAction = action;
                               // Debug.Log("ACTION " + maxAction);
                                maxDirection = direction;
                            }
                        }
                        else{
                            maxAction = action;
                            //Debug.Log("ACTION " + maxAction);
                            maxDirection = direction;
                        }
                    }
                }
            }
        }
        if (maxAction != "Attack") maxAction = "Move";
        return new EntityAction(maxAction, maxDirection);
    }

    private bool IsMeleeDirection(Location direction){
        return Math.Abs(direction.X()) + Math.Abs(direction.Y()) < 2;
    }

    public override string ToString(){
        StringBuilder stringBuilder = new StringBuilder("-------------ACTIONSELECTION--------");
        foreach (string action in _actionSelection.Keys){
            foreach (Location direction in _actionSelection[action]){
                stringBuilder.Append(action + " on " + direction + "\n");
            }
        }
        return stringBuilder.ToString();
    }
}
