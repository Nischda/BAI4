
public class ScoutEnemy : ActionRule {
	
    public void Calculate(ActionSelection actionSelection, Location location){
	    
	    actionSelection.AddV("Scout", location, -5); //avoid ramming
	    
	    //Avoid scouting near enemy
	    actionSelection.AddV("Scout", new Location(location.X()+1, location.Y()), -1);
	    actionSelection.AddV("Scout", new Location(location.X()-1, location.Y()), -1);
	    actionSelection.AddV("Scout", new Location(location.X(), location.Y()+1), -1);
	    actionSelection.AddV("Scout", new Location(location.X(), location.Y()-1), -1); 
    }
}
