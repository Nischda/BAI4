
using UnityEngine;

public class AttackAlly : ActionRule {
	
    public void Calculate(ActionSelection actionSelection, Location location){
	    //Todo: split into 
	    actionSelection.AddV("Attack", location, -50); //Attackable Enemy
    }
	
}
