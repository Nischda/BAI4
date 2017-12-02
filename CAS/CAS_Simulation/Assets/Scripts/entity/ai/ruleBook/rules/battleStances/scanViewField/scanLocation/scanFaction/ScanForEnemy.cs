
using System.Collections.Generic;
using UnityEngine;

public class ScanForEnemy : FactionRule{
	
	private readonly string _type;
	private readonly List<LocationRule> _rules = new List<LocationRule>();
	private readonly List<LocationRule> _ruleSelection;

	public ScanForEnemy(string type){
		_type = type;
		_rules.Add(new MarkEnemy(_type));
		_ruleSelection = RuleBook.GetSelection(_rules);
	}
    
	public void Calculate(ActionSelection actionSelection, Knowledge knowledge, Location location, string faction){
		
		if (faction != "Empty" && faction != knowledge.GetFaction()){
			foreach (LocationRule rule in _ruleSelection){
				rule.Calculate(actionSelection, knowledge, location);
			}
		}
	}
}
