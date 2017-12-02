    
using System;
using System.Collections.Generic;

public static class RuleBook{

    private static Random rand = new Random();
    private static float _ruleChance = 0f; //Todo make adjustable, maybe via dictionary(entity, float)
    
    
    public static List<ScanRule> GenerateRuleSelection(float viewDistance){
        List<ScanRule> ruleSelection = new List<ScanRule>();
        
        if (rand.NextDouble() >= _ruleChance){
            //Add all rules here
            ScanRule battleStance = new BattleStances();
            ruleSelection.Add(battleStance);
        }
        return ruleSelection;
    }

    public static List<T> GetSelection<T>(List<T> rules){
        List<T> ruleSelection = new List<T>();
        foreach (T rule in rules){
            if (rand.NextDouble() >= _ruleChance){
                ruleSelection.Add(rule);
            }
        }
        return ruleSelection;
    }
    
}
