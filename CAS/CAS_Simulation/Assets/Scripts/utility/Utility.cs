using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Utility : MonoBehaviour{

	private List<int[]> _directionList;
	private Dictionary<int[], string> _directionDictionary;
	private Text _popUp;
	private string _popUpValue;
	private Dictionary<string, Color> _colorDictionary;
	
	private void Awake(){
		_directionList = new List<int[]>{new[]{0, 1}, new[]{1,0},  new[]{0, -1}, new[]{-1,0}};
		_directionDictionary = new Dictionary<int[], string>{{new[]{0,1},"up"},{new[]{0,-1},"down"},{new[]{1,0},"right"},{new[]{-1,0},"left"}};
		_popUp = GameObject.Find("PopUp").GetComponent<Text>();
		_popUpValue = _popUp.text;
		
		_colorDictionary = new Dictionary<string, Color>();
		_colorDictionary.Add("red", Color.red);
		_colorDictionary.Add("blue", Color.blue);
		_colorDictionary.Add("yellow", Color.yellow);
		_colorDictionary.Add("green", Color.green);
		_colorDictionary.Add("magenta", Color.magenta);
		
	}

	public void Wait(float seconds, Action action){
		StartCoroutine(_wait(seconds, action));
	}

	IEnumerator _wait(float time, Action callback){
		yield return new WaitForSeconds(time);
		callback();
	}

	public int[] GetRandomDirection(){
		return _directionList[Random.Range(0, 4)];
	}

	public string GetDirectionName(int[] direction){
		return _directionDictionary[direction];
	}

	public void DisplayPopUp(string text){
		_popUp.text = _popUpValue + text;
		_popUp.transform.localPosition = new Vector3(0,0,0);
		Wait(2, HidePopUp);
	}

	private void HidePopUp(){
		_popUp.transform.localPosition = new Vector3(-10000,0,0);
	}
	public Color GetColor(string colorName){
		return _colorDictionary[colorName];
	}
	public string GetRandomColorName(int maxColors){
		return _colorDictionary.Keys.ToArray()[Random.Range(0, maxColors-1)];
	}
	
}