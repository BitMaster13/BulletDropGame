using UnityEngine;
public class RuneDropSlot : MonoBehaviour {
     
    [SerializeField]
    RuneShape suppoertedShapes;
    public bool IsOccupied { get; private set; }
    public DraggableRune rune { get; private set; }

    public void SetOccupied(bool occupied, DraggableRune dropedRune = null)
    {
        IsOccupied = occupied;
        rune = dropedRune;
        rune.lockRune();

    }

    public bool CanAcceptRune(DraggableRune rune)
    {
        return !IsOccupied && (rune.shape == suppoertedShapes);
    }
}
