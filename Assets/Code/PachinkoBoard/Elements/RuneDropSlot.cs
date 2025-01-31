using UnityEngine;

/*ublic class RuneDropSlot 
    [SerializeField]
    RuneShape slotShape;

    protected override void HandleDrop(GameObject droppedObject)
    {
        Debug.Log("HandleDrop in RuneDropSlot");

        Rune rune = droppedObject.GetComponent<Rune>();

        if (rune != null && rune.shape == slotShape)
        {
            Debug.Log("Item equipped to " + slotShape);

            // Put the item on the target.
            droppedObject.transform.localPosition = Vector3.zero;
        }
        else
        {
            Debug.Log("Invalid item for this slot!");
            // Snap back (optional)
            droppedObject.transform.SetParent(null);
            droppedObject.transform.position = droppedObject.GetComponent<Draggable2D>().startPosition;
        }
    }
}*/
