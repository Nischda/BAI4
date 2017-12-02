using System;
using System.Collections.Generic;

public class BattleStance : ScanRule{
    
    private readonly string _type;
    private readonly List<ScanRule> _rules = new List<ScanRule>();
    private readonly List<ScanRule> _ruleSelection;

    public BattleStance(string type){
       _type = type;
        _rules.Add(new ScanView(_type));//Todo ScanWithIntention
        _ruleSelection = RuleBook.GetSelection(_rules);
    }
    
    public void Calculate(ActionSelection actionSelection, Knowledge knowledge){
        foreach (ScanRule rule in _ruleSelection){
            rule.Calculate(actionSelection, knowledge);
        }
    }
    
}