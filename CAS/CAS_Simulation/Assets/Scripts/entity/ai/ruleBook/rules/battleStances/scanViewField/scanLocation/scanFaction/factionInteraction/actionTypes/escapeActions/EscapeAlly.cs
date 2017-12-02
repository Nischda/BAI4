
using UnityEngine;

public class EscapeAlly : ActionRule{
	
    public void Calculate(ActionSelection actionSelection, Location location){
	    actionSelection.AddV("Escape", location, -50);//Not ramming ally
	
	    //Moving to, Staying near Ally
	    actionSelection.AddV("Escape", new Location(location.X()+1, location.Y()), 1);
	    actionSelection.AddV("Escape", new Location(location.X()-1, location.Y()), 1);
	    actionSelection.AddV("Escape", new Location(location.X(), location.Y()+1), 1);
	    actionSelection.AddV("Escape", new Location(location.X(), location.Y()-1), 1);  
    }
}
