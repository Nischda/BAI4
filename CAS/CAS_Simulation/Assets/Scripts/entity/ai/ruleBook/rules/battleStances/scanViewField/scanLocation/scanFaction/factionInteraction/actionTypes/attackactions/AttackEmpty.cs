
public class AttackEmpty : ActionRule{
	
    public void Calculate(ActionSelection actionSelection, Location location){
	    
	    actionSelection.AddV("Attack", location, -10); //Attackable Enemy
    }
}
