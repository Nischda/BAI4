
using System;
using System.Collections.Generic;

public class ScanView: ScanRule{
    
    private readonly string _type;
    private readonly List<LocationRule> _rules = new List<LocationRule>();
    private readonly List<LocationRule> _ruleSelection;

    public ScanView(string type){
        _type = type;
        _rules.Add(new ScanLocation(_type));
        _ruleSelection = RuleBook.GetSelection(_rules);;
    }
    public void Calculate(ActionSelection actionSelection, Knowledge knowledge){
        Dictionary<Location, string> neighbours = knowledge.GetNeighbours();
        
        foreach (Location location in neighbours.Keys){
            foreach (LocationRule rule in _ruleSelection){
                rule.Calculate(actionSelection, knowledge, location);
            }
        }
    }
    
}
