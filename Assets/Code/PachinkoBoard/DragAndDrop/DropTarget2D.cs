using UnityEngine;
public class DropTarget2D : MonoBehaviour {
    public bool IsOccupied { get; private set; }
    public Draggable2D OccupyingObject { get; private set; }

    public void SetOccupied(bool occupied, Draggable2D occupyingObject = null)
    {
        IsOccupied = occupied;
        OccupyingObject = occupyingObject;
    }
}
