using UnityEngine;

public class ButtonManager : MonoBehaviour{

	private UIManager _uiManager;
	private Utility _utility;
	private bool _newGame = false;
	
	private void Awake(){
		_uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
		_utility = GameObject.Find("Utility").GetComponent<Utility>();
	}

	public void NewGame(){
		if (_uiManager.AreValidSettings()){
			_newGame = true;
			GameManager.NewGame();
		}
		else{
			_utility.DisplayPopUp("Too many Encounters");
		}
	}
	
	public void ResetGame(){
		if (_newGame){
			GameManager.ResetGame();
		}
		else{
			_utility.DisplayPopUp("A Game has to be created first");
		}
	}

}
