
using System;
using System.Collections.Generic;
using UnityEngine;

public class MarkEnemy : LocationRule{
    
    private readonly float _ruleChance;
    private readonly string _type;
    private readonly List<ActionRule> _rules = new List<ActionRule>();
    private List<ActionRule> _ruleSelection;

    public MarkEnemy(string type){
        _type = type;
        SetRules();
        _ruleSelection = RuleBook.GetSelection(_rules);
    }
    
    public void Calculate(ActionSelection actionSelection, Knowledge knowledge, Location location){
        foreach (ActionRule rule in _ruleSelection){
            rule.Calculate(actionSelection, location);
        }
    }

    private void SetRules(){
        switch (_type){

            case "Attack":
                _rules.Add(new AttackEnemy());
                break;
            case "Engage":
                _rules.Add(new EngageEnemy());
                break;
            case "Escape":
                _rules.Add(new EscapeEnemy());
                break;
            case "Scout":
                _rules.Add(new ScoutEnemy());
                break;
        }
    }
}
