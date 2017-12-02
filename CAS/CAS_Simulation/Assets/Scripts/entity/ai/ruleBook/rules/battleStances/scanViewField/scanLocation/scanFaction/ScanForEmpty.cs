using System;
using System.Collections.Generic;
using UnityEngine;

public class ScanForEmpty : FactionRule{

	private readonly string _type;
	private readonly List<LocationRule> _rules = new List<LocationRule>();
	private List<LocationRule> _ruleSelection;

	public ScanForEmpty(string type){
		_type = type;
		_rules.Add(new MarkEmpty(_type));
		_ruleSelection = RuleBook.GetSelection(_rules);
	}
    
	public void Calculate(ActionSelection actionSelection, Knowledge knowledge, Location location, string faction){
		if (faction== "Empty"){
			foreach (LocationRule rule in _ruleSelection){
				rule.Calculate(actionSelection, knowledge, location);
			}
		}
	}
}
