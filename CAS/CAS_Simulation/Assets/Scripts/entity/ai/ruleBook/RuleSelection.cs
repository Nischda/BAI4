

using System.Collections.Generic;
using UnityEngine;

public class RuleSelection{

	private ActionSelection _actionSelection;
	private readonly int _viewDistance;
	private readonly Entity _entity;
	private Knowledge _knowledge;
	private List<ScanRule> _ruleSelection;

	public RuleSelection(int viewDistance, Entity entity){
		_viewDistance = viewDistance;
		_entity = entity;
		GenerateRuleSelection();
	}

	private void GenerateRuleSelection(){
		_ruleSelection = RuleBook.GenerateRuleSelection(_viewDistance);
	}

	public void UpdateKnowledge(){
		_knowledge = new Knowledge(_entity, Scanner.GetNeighboursByFaction(_entity, _viewDistance));
	}

	public void Calculate(){
		_actionSelection = new ActionSelection(_viewDistance);
		
		foreach (ScanRule rule in _ruleSelection){
			//Todo create instance
		//	Debug.Log("EXECUTE RULESELECTION");
			rule.Calculate(_actionSelection, _knowledge);
		}
	}

	public EntityAction GetBestAction(){
		//sDebug.Log(_actionSelection.ToString());
		return _actionSelection.GetBestAction();
	}
}
