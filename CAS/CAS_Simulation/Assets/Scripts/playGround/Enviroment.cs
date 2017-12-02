using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Enviroment {
    
    private static Grid _grid;
    private static UIManager _uiManager;

    private static float _borderColliderBalance;
    private static float _explorationChance;
    
    public static void Reset(){
        _grid = GameObject.Find("Grid").GetComponent<Grid>();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _borderColliderBalance = PlayerPrefs.GetInt("BorderColliderBalance");
    }

    //Adds moveBalance + sum of Balances of all current encounters to entity
    public static void Move(Entity entity, Location dir){
        Location curLocation = _grid.GetEncounterLocation(entity);
        int x = dir.X() + curLocation.X(); 
        int y = dir.Y() + curLocation.Y();
        Location location = new Location(x,y);
        var collisionBalance = GetMoveBalance(entity, location);
        
        entity.AddBalance(collisionBalance +  PlayerPrefs.GetInt("ActionBalance"));
        if (entity.GetBalance() <= 0){
            DestroyEntity(entity);
        }
        else{
            if (!GetIsBlocker(location)){
                //Encountered invalid tile or  blocking encounter f.e. obstacle
                _grid.SetEncounterLocation(entity, location);
            }
            entity.GetComponent<EntityController>().InformAction();
            _uiManager.UpdateChart(entity);
        }
        _uiManager.IncrementText("Actions", 1);
        EventManager.HandleEvents();
        TurnManager.NextTurn();
    }

    public static void Attack(Entity entity, Location dir){
        Location curLocation = _grid.GetEncounterLocation(entity);
        int x = dir.X() + curLocation.X(); 
        int y = dir.Y() + curLocation.Y();
        Location location = new Location(x,y);
        var rewardBalance = GetAttackBalance(entity, location);
        
        entity.AddBalance(rewardBalance +  PlayerPrefs.GetInt("ActionBalance"));
        if (entity.GetBalance() <= 0){
            DestroyEntity(entity);
        }
        else{
            entity.GetComponent<EntityController>().InformAction();
        }
        _uiManager.IncrementText("Actions", 1);
        EventManager.HandleEvents();
        TurnManager.NextTurn();
    }
    
    public static void Wait(Entity entity){
        entity.AddBalance(PlayerPrefs.GetInt("ActionBalance"));
        if (entity.GetBalance() <= 0){
            DestroyEntity(entity);
        }
        else{
            entity.GetComponent<EntityController>().InformAction();
        }
        _uiManager.IncrementText("Actions", 1);
        EventManager.HandleEvents();
        TurnManager.NextTurn();
    }
    
    //returns sum of costs of all encountered obstacles
    private static float GetMoveBalance(Entity entity, Location location){
        if (!_grid.IsValidLocation(location)) return _borderColliderBalance;
        float balance = 0f;
        Encounter encounter = _grid.GetEncounter(location);
            if (encounter != null && entity != encounter){
                balance += encounter.GetCollisionBalance();
                encounter.OnCollision();
            }

        return balance;
    }
    
    private static float GetAttackBalance(Entity entity, Location location){
        if (!_grid.IsValidLocation(location)) return 0;
        float balance = 0f;

        Encounter encounter = _grid.GetEncounter(location);
        if ( encounter != null && entity.name != encounter.name){
        //    Debug.Log(entity + " dealt " + entity.GetAttackBalance() + "damage to " + encounter);
            encounter.AddBalance(entity.GetAttackBalance());
            if (encounter.GetBalance() <= 0){
                balance += encounter.GetRewardBalance();
                if (encounter.GetType().Name == "Entity"){
               //    Debug.Log(entity.name + " destroyed " + encounter.name + " and received: " + encounter.GetRewardBalance());
                   RemoveEncounter(encounter, location);
                   TurnManager.RemoveController(encounter.GetComponent<EntityController>());
                }
            }
        }
        return balance;
    }

    private static void DestroyEntity(Entity entity){
        TurnManager.RemoveController(entity.GetComponent<EntityController>());
        _grid.RemoveEntity(entity);
        Object.Destroy(entity.gameObject);
    }

    private static void RemoveEncounter(Encounter encounter, Location location){
        _grid.RemoveEncounter(encounter, location);
        Object.Destroy(encounter.gameObject);
    }
    
    private static bool GetIsBlocker(Location location){
        if(!_grid.IsValidLocation(location)) return true;
        
        Encounter encounter = _grid.GetEncounter(location);
        if (encounter != null){
        }
        return encounter != null && encounter.IsBlocker();
    }

    private static void UpdateUi(Entity entity){
        _uiManager.IncrementText("Actions", 1);
        _uiManager.UpdateChart(entity);
    }

}