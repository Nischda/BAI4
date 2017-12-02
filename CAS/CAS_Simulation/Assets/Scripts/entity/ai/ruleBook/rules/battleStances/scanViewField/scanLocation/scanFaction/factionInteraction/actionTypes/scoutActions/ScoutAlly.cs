
public class ScoutAlly : ActionRule {
	
    public void Calculate(ActionSelection actionSelection, Location location){
	    
	    actionSelection.AddV("Scout", location, -50);//Not ramming ally
	
	    //Moving away from ally
	    actionSelection.AddV("Scout", new Location(location.X()+1, location.Y()), -1);
	    actionSelection.AddV("Scout", new Location(location.X()-1, location.Y()), -1);
	    actionSelection.AddV("Scout", new Location(location.X(), location.Y()+1), -1);
	    actionSelection.AddV("Scout", new Location(location.X(), location.Y()-1), -1);  
    }
}
