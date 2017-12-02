
public class EngageEmpty : ActionRule {
	
    public void Calculate(ActionSelection actionSelection, Location location){
	    actionSelection.AddV("Engage", location, 0.1f); //At least no collision
    }
}
