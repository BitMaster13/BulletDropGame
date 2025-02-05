using UnityEngine;
public class RuneDropSlot : MonoBehaviour {
     
    [SerializeField]
    RuneShape suppoertedShapes;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Color acceptColor = Color.yellow;
    [SerializeField]
    private Color rejectColor = Color.yellow;
    
    private Color originalColor;
    public bool IsOccupied { get; private set; }
    public DraggableRune rune { get; private set; }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

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

    public void OnRuneHover(DraggableRune rune)
    {
        if (CanAcceptRune(rune))
        {
            spriteRenderer.color = acceptColor;
        } else{
            spriteRenderer.color = rejectColor;
        }
    }

    public void OnRuneExit()
    {
        spriteRenderer.color = originalColor;
    }
}
