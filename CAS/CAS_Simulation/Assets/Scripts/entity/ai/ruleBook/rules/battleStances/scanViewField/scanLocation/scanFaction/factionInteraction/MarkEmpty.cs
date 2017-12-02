
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class MarkEmpty : LocationRule{
    
    private readonly float _ruleChance;
    private readonly string _type;
    private readonly List<ActionRule> _rules = new List<ActionRule>();
    private List<ActionRule> _ruleSelection;

    public MarkEmpty(string type){
        _type = type;
        SetRules();
        _ruleSelection = RuleBook.GetSelection(_rules);
    }
    
    public void Calculate(ActionSelection actionSelection, Knowledge knowledge, Location location){
        foreach (ActionRule rule in _ruleSelection){
           rule.Calculate(actionSelection, location);
        }
    }

    //Todo need all?
    private void SetRules(){
        switch (_type){

            case "Attack":
                _rules.Add(new AttackEmpty());
                break;
            case "Engage":
                _rules.Add(new EngageEmpty());
                break;
            case "Escape":
                _rules.Add(new EscapeEmpty());
                break;
            case "Scout":
                _rules.Add(new ScoutEmpty());
                break;
        }
    }
}