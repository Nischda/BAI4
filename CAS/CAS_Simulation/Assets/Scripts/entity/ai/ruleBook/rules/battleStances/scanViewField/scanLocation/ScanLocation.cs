
using System;
using System.Collections.Generic;
using System.Diagnostics;
using  UnityEngine;
using Debug = UnityEngine.Debug;

// ->BattleStance->ViewField->Location->Faction->Tiles->Tile
public class ScanLocation : LocationRule{
	
	private readonly string _type;
	private readonly List<FactionRule> _rules = new List<FactionRule>();
	private List<FactionRule> _ruleSelection;
	
	    
	public ScanLocation(String type){
		_type = type;
		//Scan for factions
		_rules.Add(new ScanForAlly(_type));
		_rules.Add(new ScanForEnemy(_type));
		_rules.Add(new ScanForEmpty(_type));
		_ruleSelection = RuleBook.GetSelection(_rules);
	}

	public void Calculate(ActionSelection actionSelection, Knowledge knowledge, Location location){
		String faction = knowledge.GetFactionOn(location);
		foreach (FactionRule rule in _ruleSelection){
			rule.Calculate(actionSelection, knowledge, location, faction);
		}
	}
}