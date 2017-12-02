using UnityEngine;

public class Obstacle : Encounter{

    private string _faction = "Neutral";
    private float _resources;
    private bool _isBlocker;
    private float _collisionBalance;
    private float _rewardBalance;
    
    private void Awake(){
        _isBlocker = 1 == PlayerPrefs.GetInt("ObstaclesBlockTile"); // 1 == true, 0 == false
        _collisionBalance = PlayerPrefs.GetInt("ObstacleColliderBalance");
        _rewardBalance = PlayerPrefs.GetInt("ObstacleRewardBalance");
    }
    
    public override void Reset(){
        _resources = PlayerPrefs.GetInt("EntityStartBalance");
    }
    
    public override float GetBalance(){
        return _resources;
    }

    public override void AddBalance(float f){
        _resources += f;
    }

    public override float GetCollisionBalance(){
        return _collisionBalance;
    }

    public override float GetRewardBalance(){
        return _rewardBalance;
    }

    public override string GetFaction(){
        return _faction;
    }

    public override void OnCollision(){
        //no event
    }

    public override void OnAttacked(){
        //no event
    }

    public override bool IsBlocker(){
        return _isBlocker;
    }
}
