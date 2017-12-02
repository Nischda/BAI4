using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityController{

    private Entity _entity;
    private InputController _inputController;
    private Color _baseColor;

    private void Awake(){
        _inputController = GameObject.Find("InputController").GetComponent<InputController>();
        _baseColor = GetComponent<Renderer>().material.color;
        _entity = transform.GetComponent<Entity>();
    }
    
    public override void SetBaseColor(Color color){
        _baseColor = color;
    }
	
    public override void ManageActions(int turns){
        _inputController.WaitForPlayerInput(_entity);
    }

    public override void Highlight(){
    //    GetComponent<Renderer>().material.color = Color.cyan;
    }

    public override void UnHighlight(){
        GetComponent<Renderer>().material.color = _baseColor;
    }

    public override void InformAction(){
        //nothing
    }
}