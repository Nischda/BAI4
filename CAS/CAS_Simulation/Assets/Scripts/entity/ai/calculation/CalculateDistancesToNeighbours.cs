/*
using System;
using System.Collections.Generic;

public class DistancesToNeighbours : Rule{

    public override ActionSelection Calculate(ActionSelection actionSelection, Dictionary<string, List<Location>> neighboursByFaction){
        Dictionary<string, Dictionary<Location, int>> distancesToNeighbours = new Dictionary<string, Dictionary<Location, int>>();
        foreach (string faction in neighboursByFaction.Keys){
            foreach (Location location in neighboursByFaction[faction]){
                int distance = Math.Abs(location.X()) + Math.Abs(location.Y());
                                   
                if (!distancesToNeighbours.ContainsKey(faction)){
                    distancesToNeighbours.Add(faction, new Dictionary<Location, int>());
                }
                distancesToNeighbours[faction].Add(location,distance);
            }
        }

    }
}
*/