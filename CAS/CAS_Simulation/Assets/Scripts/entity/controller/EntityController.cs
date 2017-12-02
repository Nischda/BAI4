using UnityEngine;

public abstract class EntityController  : MonoBehaviour{

    public abstract void SetBaseColor(Color color);
    public abstract void ManageActions(int turns);
    public abstract void Highlight();
    public abstract void UnHighlight();
    public abstract void InformAction();
}
