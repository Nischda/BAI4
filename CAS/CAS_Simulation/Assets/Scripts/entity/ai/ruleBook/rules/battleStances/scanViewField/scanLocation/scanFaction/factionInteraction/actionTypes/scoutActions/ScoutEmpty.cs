
using UnityEngine;

public class ScoutEmpty : ActionRule{
	
    public void Calculate(ActionSelection actionSelection, Location location){
        actionSelection.AddV("Scout", location, 1f); //avoid ramming
	    
        //Avoid scouting near enemy
        actionSelection.AddV("Scout", new Location(location.X()+1, location.Y()), 0.1f);
        actionSelection.AddV("Scout", new Location(location.X()-1, location.Y()), 0.1f);
        actionSelection.AddV("Scout", new Location(location.X(), location.Y()+1), 0.1f);
        actionSelection.AddV("Scout", new Location(location.X(), location.Y()-1), 0.1f); 
    }
}