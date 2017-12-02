public class EntityAction {

    private readonly string _action;
    private readonly Location _direction;
    
    public EntityAction(string action, Location direction){
        _action = action;
        _direction = direction;
    }
    
    public string ActionType(){ return _action;}
    public Location Direction(){ return _direction; }

    public override string ToString(){
        return _action + " on " + _direction;
    }
}
