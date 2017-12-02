using UnityEngine;

public  class InputController : MonoBehaviour{
    private bool _playerInput;
    private Entity _curEntity;

    public void Reset(){
        _playerInput = false;
    }

    private void Awake(){
        Reset();
    }

    public void WaitForPlayerInput(Entity entity){
        _curEntity = entity;
        _playerInput = true;
    }
    
    private void Update(){
        if (!_playerInput) return;
        if (!Input.anyKeyDown) return;
        
        if (Input.GetKeyDown(KeyCode.W)){
            ValidAction();
            Actions.Move(_curEntity, new Location(0,1));
        }
        else if (Input.GetKeyDown(KeyCode.D)){
            ValidAction();
            Actions.Move(_curEntity, new Location(1,0));
        }
        else if (Input.GetKeyDown(KeyCode.S)){
            ValidAction();
            Actions.Move(_curEntity, new Location(0,-1));
        }
        else if (Input.GetKeyDown(KeyCode.A)){
            ValidAction();
            Actions.Move(_curEntity, new Location(-1,0));
        }
        
        else if (Input.GetKeyDown(KeyCode.UpArrow)){
            ValidAction();
            Actions.Attack(_curEntity, new Location(0,1));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)){
            ValidAction();
            Actions.Attack(_curEntity, new Location(1,0));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)){
            ValidAction();
            Actions.Attack(_curEntity, new Location(0,-1));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            ValidAction();
            Actions.Attack(_curEntity, new Location(-1,0));
        }
    }

    private void ValidAction(){
        _playerInput = false;
    }
}
