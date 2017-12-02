/*
using System.Collections.Generic;

public class CalculateDirectNeighbours : Rule{
    
    public override void Calculate(Entity entity){
        //Todo Calculate DistancesToNeighbours
     //  entity.get
        Dictionary<Location, string> directNeighbours =  CalculateDirectNeighbours(Dictionary<string, Dictionary<Location,int>> distanceToFactions){
            Dictionary<Location, string> directNeighbours = new Dictionary<Location, string>();
            foreach ( string faction in  distanceToFactions.Keys){
                Dictionary<Location, int> distanceToFactionEncounter = distanceToFactions[faction];
                foreach (Location location in distanceToFactionEncounter.Keys){
                    //Debug.Log(_entity.name + " has possible neighbour: " + location[0] + "|" + location[1] + "on distance: " + distanceToFactionEncounter[location]);
                    if (distanceToFactionEncounter[location] == 1){
                        directNeighbours.Add(location, faction);
                        //Debug.Log(_entity.name + " has neighbour: " + location[0] + "|" + location[1]);
                    }
                }
            }
            return directNeighbours;
        }
    }
    
}
*/