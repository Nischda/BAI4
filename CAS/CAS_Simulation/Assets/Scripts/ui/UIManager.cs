using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour{

	private GraphDescription _graphDescription;
	private CameraManager _cameraManager;
	
	//TEXT
	private Dictionary<string, Text> _textDictionary;
	private Dictionary<string, string> _textValDictionary;
	private Dictionary<string, int> _textCountDictionary;

	//SLIDER
	private Dictionary<string, Text> _sliderTextDictionary;
	private Dictionary<string, string> _sliderTextValDictionary;
	private Dictionary<string, int> _sliderValDictionary;
	
	//HIDE
	public GameObject SettingsGo;
	public Toggle HideSettingsGo;
	public GameObject ChartGo;
	public Toggle HideChartGo;
	
	//CHART
	public LineChart LineChart;
	private float[][] _data; 

	private void Awake(){
		_graphDescription = GameObject.Find("GraphDescription").GetComponent<GraphDescription>();
		_cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
		InitText();
		InitSlider();
	}

	public bool AreValidSettings(){
		int tileCount = PlayerPrefs.GetInt("Width") * PlayerPrefs.GetInt("Height");
		int encounterCount = 0;
		encounterCount += PlayerPrefs.GetInt("AiEntityCount");
		encounterCount += PlayerPrefs.GetInt("PlayerEntityCount");
		encounterCount += PlayerPrefs.GetInt("GoalCount");
		encounterCount += PlayerPrefs.GetInt("ObstacleCount");

		return encounterCount <= tileCount;
	}
	
	public void ResetRound(){
		_textCountDictionary["Turns"] = 0;
		_textCountDictionary["Actions"] = 0;
		_textCountDictionary["Agents"] = 0;
		IncrementText("Agents", _sliderValDictionary["AiEntityCount"] + _sliderValDictionary["PlayerEntityCount"]);
		
		InitChart();
		InitToggles();
	}
	
	public void ResetGame(){
		ResetRound();
		_textCountDictionary["Rounds"] = 0;
		_cameraManager.AdjustDistanceToGrid();
	}

	//TOGGLES
	private void InitToggles(){
		foreach (Transform child in GameObject.Find("Toggles").transform){
			Toggle toggle = child.GetComponent<Toggle>();
			int intBool = 0;
			if (toggle.isOn){intBool = 1;}
			PlayerPrefs.SetInt(toggle.name, intBool);
		}
	}

	//TEXT
	private void InitText(){
		_textDictionary = new Dictionary<string, Text>();
		_textValDictionary = new AttributeDictionary();
		_textCountDictionary = new Dictionary<string, int>();
		SetText();
	}

	private void SetText(){
		foreach (Transform child in GameObject.Find("TextGroup").transform){
			Text text = child.GetComponent<Text>();
			_textDictionary.Add(text.name, text);
			string key = text.name;
			_textValDictionary[key] = text.text;
			_textCountDictionary[key] = 0;
			text.text += _textCountDictionary[key];
		}
	}
	
	public void IncrementText(string key, int count){
		_textCountDictionary[key] += count;
		_textDictionary[key].text = _textValDictionary[key] + _textCountDictionary[key];
		PlayerPrefs.SetInt("Turns", _textCountDictionary[key]);
	}

	
	//SLIDER
	private void InitSlider(){
		_sliderValDictionary = new Dictionary<string, int>();
		_sliderTextDictionary = new Dictionary<string, Text>();
		_sliderTextValDictionary = new Dictionary<string, string>();
		SetSlider();
	}
	/// <summary>
	/// Initializes all necessary components and values of a slider in dictionaries
	/// Saves base playerprefs and sets base values in slider text component
	/// All slider has its own key represented by its name
	/// All Values have to be int
	/// </summary>
	private void SetSlider(){
		foreach (Transform child in GameObject.Find("SliderGroup").transform){
			Slider slider = child.GetComponent<Slider>();
			string key = slider.name;
			_sliderTextDictionary[key] = slider.GetComponentInChildren<Text>();
			_sliderTextValDictionary[key] = _sliderTextDictionary[key].text;
			_sliderValDictionary[key] = (int)slider.value;
			UpdateSlider(slider);
		}
	}
	
	public void UpdateSlider(Slider slider){
		string key = slider.name;
		PlayerPrefs.SetInt(key, _sliderValDictionary[key]);
		_sliderTextDictionary[key].text = _sliderTextValDictionary[key] + PlayerPrefs.GetInt(key);
		_sliderValDictionary[key] = (int) slider.value; //slider.value;
	}
	
	//SETTER
	public void HideSettings(){
		HideGo(SettingsGo);
	}
	
	public void HideChart(){
		HideGo(ChartGo);
	}

	private void HideGo(GameObject go){
		if (go.transform.localPosition.x <= -10000){
			go.transform.localPosition += new Vector3(-go.transform.localPosition.x, 0, 0);
		}
		else{
			go.transform.localPosition += new Vector3(-10000, 0, 0);
		}
	}
	
	//CHART
	private void InitChart () {
		_data = new float[_textCountDictionary["Agents"]][];
		for(int i=0;i<_data.Length;i++) {
			_data[i] = new float[PlayerPrefs.GetInt("ChartWidth")]; 
			for(int j=0;j<PlayerPrefs.GetInt("ChartWidth");j++) {
				_data[i][j] = 0; //placeholder
			}
		}
	}
	
	public void UpdateChart(Entity entity){
		_data[entity.Id][_textCountDictionary["Turns"] % PlayerPrefs.GetInt("ChartWidth")] = entity.GetBalance(); //Overrides existing values starting left 
		LineChart.UpdateData(_data);
		_graphDescription.UpdateAxisDescriptions();
	}
}
