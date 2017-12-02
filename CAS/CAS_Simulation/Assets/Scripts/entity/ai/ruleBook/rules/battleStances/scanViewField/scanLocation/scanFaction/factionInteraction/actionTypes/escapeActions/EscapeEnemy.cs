
public class EscapeEnemy : ActionRule{

    public void Calculate(ActionSelection actionSelection, Location location){

	    actionSelection.AddV("Escape", location, -5); //Ram enemy if necessary?
	
	    //Avoid staying next to Enemy
	    actionSelection.AddV("Escape", new Location(location.X()+1, location.Y()), -1);
	    actionSelection.AddV("Escape", new Location(location.X()-1, location.Y()), -1);
	    actionSelection.AddV("Escape", new Location(location.X(), location.Y()+1), -1);
	    actionSelection.AddV("Escape", new Location(location.X(), location.Y()-1), -1);  
    }
}
