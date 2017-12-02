using System;
using System.Collections.Generic;
using UnityEngine;

public class ScanForAlly : FactionRule{
	
	private readonly string _type;
	private readonly List<LocationRule> _rules = new List<LocationRule>();
	private readonly List<LocationRule> _ruleSelection;

	public ScanForAlly(String type){
		_type = type;
		_rules.Add(new MarkAlly(_type));
		_ruleSelection = RuleBook.GetSelection(_rules);
	}
    
	public void Calculate(ActionSelection actionSelection, Knowledge knowledge, Location location, string faction){
		if (faction == knowledge.GetFaction()){
		//	Debug.Log(faction + " other faction: " + knowledge.GetFaction());
			if (location.IsDirection()){
				foreach (LocationRule rule in _ruleSelection){
					rule.Calculate(actionSelection, knowledge, location);
				}
			}
		}
	}
}
