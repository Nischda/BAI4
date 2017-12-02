
public class EngageEnemy : ActionRule {
	
    public void Calculate(ActionSelection actionSelection, Location location){
	    actionSelection.AddV("Engage", location, -20); //Ramming Enemy
	    
	    //Moving into Attack Range
	    actionSelection.AddV("Engage", new Location(location.X()+1, location.Y()), 1);
	    actionSelection.AddV("Engage", new Location(location.X()-1, location.Y()), 1);
	    actionSelection.AddV("Engage", new Location(location.X(), location.Y()+1), 1);
	    actionSelection.AddV("Engage", new Location(location.X(), location.Y()-1), 1);  
    }
}
