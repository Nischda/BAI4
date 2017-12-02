using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Encounter : MonoBehaviour{

	public abstract void Reset();
	public abstract float GetBalance();
	public abstract void AddBalance(float f);
	public abstract float GetCollisionBalance();
	public abstract float GetRewardBalance();
	public abstract string GetFaction();
	public abstract void OnCollision();
	public abstract void OnAttacked();
	public abstract bool IsBlocker();
}
