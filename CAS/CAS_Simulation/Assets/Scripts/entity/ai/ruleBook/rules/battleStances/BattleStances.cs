
using System.Collections.Generic;

public class BattleStances : ScanRule{
    
    private readonly List<ScanRule> _rules = new List<ScanRule>();
    private readonly List<ScanRule> _ruleSelection;

    public BattleStances(){
        _rules.Add(new BattleStance("Attack"));
        _rules.Add(new BattleStance("Engage"));
        _rules.Add(new BattleStance("Escape"));
        _rules.Add(new BattleStance("Scout"));
      //To be defined  _rules.Add(new BattleStance(_ruleChance, "Assist"));
        _ruleSelection = RuleBook.GetSelection(_rules);
    }

    public void Calculate(ActionSelection actionSelection, Knowledge knowledge){
        foreach (ScanRule battleStance in _ruleSelection){
            battleStance.Calculate(actionSelection, knowledge);
        }
    }
}
