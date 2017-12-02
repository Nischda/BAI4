using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour {

	public abstract void ChooseAction();
	public abstract void UpdateQ();
}
