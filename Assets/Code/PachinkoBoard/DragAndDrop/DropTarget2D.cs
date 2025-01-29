using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DropTarget2D : MonoBehaviour, IDropHandler
{
    public virtual void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop called on DropTarget2D: " + gameObject.name);
        Debug.Log("Draggable2D.draggedObject: " + Draggable2D.draggedObject);
        if (Draggable2D.draggedObject == null){
            Debug.LogError("No object being dragged!");
            return;
        }

        // Call the abstract method
        HandleDrop(Draggable2D.draggedObject);
    }

    protected abstract void HandleDrop(GameObject droppedObject);
}
