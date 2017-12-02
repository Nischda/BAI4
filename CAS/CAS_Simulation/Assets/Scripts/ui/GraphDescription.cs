using System;
using System.Collections.Generic;
using UnityEngine;

public class GraphDescription : MonoBehaviour{

	public LineChart LineChart;
	public string XTypeString;
	public string YTypeString;
	
	
	public GameObject XDescription;
	public GameObject YDescription;
	public TextMesh XTypeTextMesh;
	public TextMesh YTypeTextMesh;

	private void Awake(){
		InitAxisTypes();
		UpdateAxisDescriptions();
	}

	private void InitAxisTypes(){
		XTypeTextMesh.text = XTypeString;
		YTypeTextMesh.text = YTypeString;
	}

	public void UpdateAxisDescriptions(){
		SetAxisDescription(GetTextMeshList(XDescription), 0, PlayerPrefs.GetInt("ChartWidth"));
		SetAxisDescription(GetTextMeshList(YDescription), (int)LineChart.mMin, (int)LineChart.mMax);
	}
	
	private static List<TextMesh> GetTextMeshList(GameObject description){
		List<TextMesh> meshList = new List<TextMesh>();

		foreach (Transform child in description.transform){
			meshList.Add(child.GetComponent<TextMesh>());
		}
		return meshList;
	}
	
	private void SetAxisDescription(List<TextMesh> meshList, int min, int max){
		float abs = max - min;
		for (int i = 0; i < meshList.Count; i++){
			float factor = i *0.2f;
			meshList[i].text = "" + Math.Round(min + abs * factor);
		}
	}
}
