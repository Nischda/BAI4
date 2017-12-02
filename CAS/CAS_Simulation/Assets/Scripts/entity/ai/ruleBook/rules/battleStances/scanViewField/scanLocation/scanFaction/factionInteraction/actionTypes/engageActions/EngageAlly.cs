
public class EngageAlly : ActionRule {
	
    public void Calculate(ActionSelection actionSelection, Location location){
	    actionSelection.AddV("Engage", location, -100); //Ramming Enemy
	    
	    //Moving into Attack Range
	    actionSelection.AddV("Engage", new Location(location.X()+1, location.Y()), 0.5f);
	    actionSelection.AddV("Engage", new Location(location.X()-1, location.Y()), 0.5f);
	    actionSelection.AddV("Engage", new Location(location.X(), location.Y()+1), 0.5f);
	    actionSelection.AddV("Engage", new Location(location.X(), location.Y()-1), 0.5f);  
    }
}
