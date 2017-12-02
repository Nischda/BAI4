using System.Collections.Generic;
using UnityEngine;

public class EntityFactory : MonoBehaviour{

    public Grid Grid;

    public Obstacle Obstacle;
    public Entity PlayerEntity;
    public Entity AiEntity;

    private Utility _utility;
    private int _obstacleCount;
    private int _playerEntityCount;
    private int _aiEntityCount;
    private List<string> _factionNameList;
    private int _facionCount;

    private void InitializePrefs(){
        _utility = GameObject.Find("Utility").GetComponent<Utility>();
        _aiEntityCount = PlayerPrefs.GetInt("AiEntityCount");
        _playerEntityCount = PlayerPrefs.GetInt("PlayerEntityCount");
        _obstacleCount = PlayerPrefs.GetInt("ObstacleCount");
        _factionNameList = CreateFactionNameList(5);
        _facionCount = _factionNameList.Count;
    }

    private List<string> CreateFactionNameList(int length){
        List<string> factionNameList = new List<string>();
        for (int i = 0; i < length; i++){
            factionNameList.Add(_utility.GetRandomColorName(5));
        }
        return factionNameList;
    }
    
    public void CreateEntities(){
        InitializePrefs();
        Grid.FillGrid(CreateObstacle, _obstacleCount); //CreateObstacles();
        Grid.FillGrid(CreatePlayerEntity, _playerEntityCount);//CreateEntities();
        Grid.FillGrid(CreateAiEntity, _aiEntityCount);//CreateuseEntities();
        Grid.Center();
    }
    
    //Create obstacles on coordinates
    private Obstacle CreateObstacle(int x, int z, int obstaclesPlaced) {
        var obstacle = Instantiate(Obstacle);
        obstacle.transform.localPosition = Grid.GetVector3(x, z);
        obstacle.transform.SetParent(Grid.transform);
        obstacle.name = "Obstacle" + obstaclesPlaced + "_" + x + "_" + z;
        return obstacle;
    }
	
    //Create playetEntity on coordinates
    private Entity CreatePlayerEntity(int x, int z, int entitiesPlaced){
        var entity = Instantiate(PlayerEntity);
        entity.transform.localPosition = Grid.GetVector3(x, z);
        entity.transform.SetParent(Grid.transform);
        entity.name = "PlayerEntity" + entitiesPlaced;
        entity.Id = entitiesPlaced;
        entity.Faction = _factionNameList[entitiesPlaced % _facionCount];//Todo hard coded for test purposes:_factionNameList[entitiesPlaced];
        entity.GetComponent<EntityController>().SetBaseColor( _utility.GetColor( entity.Faction));
        TurnManager.AddController(entity.GetComponent<PlayerController>());
        return entity;
    }
    
    //Create Goal on coordinates
    private Entity CreateAiEntity(int x, int z, int entitiesPlaced){
        var entity = Instantiate(AiEntity);
        entity.transform.localPosition = Grid.GetVector3(x, z);
        entity.transform.SetParent(Grid.transform);
        entity.name = "AiEntity" + entitiesPlaced;
        entity.Id = entitiesPlaced + _playerEntityCount; //playerEntities get added first and entities need unique id. 
        entity.Faction = _factionNameList[entitiesPlaced % _facionCount]; 
        entity.GetComponent<EntityController>().SetBaseColor( _utility.GetColor( entity.Faction));
        TurnManager.AddController(entity.GetComponent<AiController>());
        return entity;
    }

}
