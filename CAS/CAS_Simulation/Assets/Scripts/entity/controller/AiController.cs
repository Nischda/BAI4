using UnityEngine;

public class AiController : EntityController {

	private Agent _agent;
	private Color _baseColor;
    
	
	private void Awake(){
		_agent = GetComponent<Agent>();
		_baseColor = GetComponent<Renderer>().material.color;
	}

	public override void SetBaseColor(Color color){
		_baseColor = color;
		GetComponent<Renderer>().material.color = _baseColor;
	}
	
	public override void ManageActions(int turns){
		_agent.ChooseAction();
	}
	
	public override void Highlight(){
		GetComponent<Renderer>().material.color = Color.magenta;
	}

	public override void UnHighlight(){
		GetComponent<Renderer>().material.color = _baseColor;
	}

	public override void InformAction(){
		_agent.UpdateQ();
	}
}
