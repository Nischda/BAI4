using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QNodeFactory : MonoBehaviour{

	public GameObject QNode;
	private Grid _grid;

	private void Awake(){
		_grid = GameObject.Find("Grid").GetComponent<Grid>();
	}

	public void UpdateQNode(int x, int y, string action, decimal val){
		GameObject qNode = GameObject.Find("QNode"+ x + "_" + y + action);
		if (!qNode){
			qNode = Instantiate(QNode);
			qNode.transform.SetParent(_grid.transform);
			qNode.transform.localPosition = _grid.GetVector3(x, y);
			MoveNodeToEdge(qNode, action);
			qNode.name = "QNode" + x + "_" + y + action;
		}
		qNode.GetComponent<TextMesh>().text = "" + val;
	}

	private void MoveNodeToEdge(GameObject qNode, string action){
		switch (action){
			case "Up":
				qNode.transform.localPosition += new Vector3(0,-0.4f,0.4f);
				break;
			case "Right":
				qNode.transform.localPosition += new Vector3(0.4f,-0.4f,0);
				qNode.transform.localRotation = Quaternion.Euler(90, -90, 0);
				break;
			case "Down":
				qNode.transform.localPosition += new Vector3(0,-0.4f,-0.4f);
				break;
			case "Left":
				qNode.transform.localPosition += new Vector3(-0.4f,-0.4f,0);
				qNode.transform.localRotation = Quaternion.Euler(90, -90, 0);
				break;
		}
	}
}
