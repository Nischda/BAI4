using System;
using UnityEngine;

public class Entity : Encounter{

    public int Id;
    public string Faction;
    private TextMesh _resourceText;
    private float _resources;
    private float _collisionBalance;
    private float _attackDamage;
    private float _rewardBalance;

    private void Awake(){
        _resourceText = GetComponentInChildren<TextMesh>();
        _resources = PlayerPrefs.GetInt("EntityStartBalance");
        _collisionBalance = PlayerPrefs.GetInt("EntityColliderBalance");
        _attackDamage = PlayerPrefs.GetInt("EntityAttackBalance");
        _rewardBalance = PlayerPrefs.GetInt("EntityRewardBalance");
        UpdateResourceText();
    }

    //ENTITY
    private void UpdateResourceText(){
        _resourceText.text = ""+ _resources;
    }

    public float GetAttackBalance(){
        return _attackDamage;
    }
    
    //ENCOUNTER
    public override void Reset(){
        _resources = PlayerPrefs.GetInt("EntityStartBalance");
    }
    
    public override float GetBalance(){
        return _resources;
    }
    public override void AddBalance(float f){
        _resources += f;
        UpdateResourceText();
    }

    public override float GetCollisionBalance(){
        return _collisionBalance;
    }

    public override float GetRewardBalance(){
        return _rewardBalance;
    }
    
    public override string GetFaction(){
        return Faction;
    }


    public override bool IsBlocker(){
        return true;
    }


    public override void OnCollision(){
    }
    public override void OnAttacked(){
    }
}