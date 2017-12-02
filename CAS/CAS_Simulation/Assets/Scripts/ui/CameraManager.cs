using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class CameraManager : MonoBehaviour{

	private Camera _camera;

	private void Awake(){
		_camera = GetComponent<Camera>();

	}

	public void AdjustDistanceToGrid(){
		int width = PlayerPrefs.GetInt("Width");
		int height = PlayerPrefs.GetInt("Height");
		float offset = PlayerPrefs.GetInt("Offset")/100f;
		int size = width;
		if (height > width){
			size = height;
		}
		_camera.orthographicSize = (1+offset) * size / 1.75f +1;
	}
}
