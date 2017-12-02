
using System.Collections.Generic;
using UnityEngine;

public class MarkAlly : LocationRule{
    
    private readonly float _ruleChance;
    private readonly string _type;
    private readonly List<ActionRule> _rules = new List<ActionRule>();
    private List<ActionRule> _ruleSelection;

    public MarkAlly(string type){
        _type = type;
        SetRules();
        _ruleSelection = RuleBook.GetSelection(_rules);
    }
    
    public void Calculate(ActionSelection actionSelection, Knowledge knowledge, Location location){
        foreach (ActionRule rule in _ruleSelection){
            rule.Calculate(actionSelection, location);
        }
    }

    //Todo remove knowledge and make actionrule inherit?
    private void SetRules(){
        switch (_type){

            case "Attack":
                _rules.Add(new AttackAlly());
                break;
            case "Engage":
                _rules.Add(new EngageAlly());
                break;
            case "Escape":
                _rules.Add(new EscapeAlly());
                break;
            case "Scout":
                _rules.Add(new ScoutAlly());
                break;
        }
    }
}
