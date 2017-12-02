
using UnityEngine;

public class AttackEnemy : ActionRule{
	
    public void Calculate(ActionSelection actionSelection, Location location){
	    actionSelection.AddV("Attack", location, 50f); //Attackable Enemy
    }
}
