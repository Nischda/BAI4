public class EscapeEmpty : ActionRule{
	
    public void Calculate(ActionSelection actionSelection, Location location){
	    
	    actionSelection.AddV("Escape", location, 0.5f); //No collision or enemy
	    //No need to give narby tiles bonus, as found enemies will give bad tiles malus.
    }
}
